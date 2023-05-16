using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text;
using System;
using Desafio.BancoCarrefour.Authentication.DTOs;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Desafio.BancoCarrefour.Authentication.DAOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Desafio.BancoCarrefour.Authentication.Services.Interfaces;
using Desafio.BancoCarrefour.Authentication.Helper;
using Desafio.BancoCarrefour.Authentication.Repository.Interfaces;
using System.Linq;

namespace Desafio.BancoCarrefour.Authentication.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;

        public TokenService(IConfiguration configuration, IUserService userService, IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userService = userService;
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
        }
        public async Task<LoginReturnDTO> GenerateToken(LoginDTO loginDTO)
        {
            try
            {
                //Autentica UserName e Senha 
                var user = await _userService.ValidaLogin(loginDTO);
                if (user == null)
                {
                    return new LoginReturnDTO { Error = new ErrorBaseDTO { Codigo = "002", Mensagem = "Usuario/Senha Invalido." } };
                }
                //Monta os Claims que constaram no Token JWT
                return await GenerateToken(user);
            }
            catch (Exception ex)
            {
                return new LoginReturnDTO { Error = new ErrorBaseDTO { Codigo = "001", Mensagem = $"Ocorreu um erro inesperado= {ex.Message}" } };
            }
        }

        public async Task<LoginReturnDTO>  GenerateToken(UserDAO user)
        {
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                    new Claim(JwtRegisteredClaimNames.GivenName, $"{user.FirstName} {user.LastName}"),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id)
                };
            claims.Add(new Claim(ClaimTypes.Role, user.Role.RoleName));

            // Crie a chave secreta para assinar o token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AuthSecret")));

            // Crie o token JWT
            var token = new JwtSecurityToken(
                issuer: "https://rs3.com", // Emitente do token
                audience: "https://rs3.com", // Audiência do token
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("TokenValidateMinutes")), // Data de expiração do token
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // Gere o token JWT como uma string
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = await GenerateRefreshToken(user.UserName);

            var tokenReturn = new LoginReturnDTO
            {
                Token = tokenString,
                TokenExpiration = token.ValidTo,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresAt
            };

            // Retorne o token JWT gerado
            return tokenReturn;

        }
        public async Task<RefreshTokenDAO> GenerateRefreshToken(string userId)
        {
            try
            {
                var refreshToken = new RefreshTokenDAO
                {
                    Id = Guid.NewGuid().ToString(),
                    Token = Guid.NewGuid().ToString(),
                    ExpiresAt = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("RefreshTokenValidateMinutes")),
                    UserId = userId,
                    Date = DateTime.UtcNow
                };

                await _refreshTokenRepository.SaveRefreshTokenAsync(refreshToken);

                return refreshToken;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao renovar o token. {ex.Message}");
            }
        }

        public async Task<LoginReturnDTO> RefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            try
            {
                var userName = string.Empty;
                var principal = TokenHelper.GetPrincipalFromExpiredToken(refreshTokenDTO.Token, _configuration);
                var claimSub = principal.Claims.Where(c => c.Type == "http=//schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").FirstOrDefault();
                if (claimSub != null)
                {
                    userName = claimSub.Value;
                }
                else
                {
                    return new LoginReturnDTO { Error = new ErrorBaseDTO { Codigo = "004", Mensagem = $"Token inválido" } };
                }
                
                // Valida o refresh token no banco de dados
                var refreshTokenDAO = new RefreshTokenDAO();
                var storedRefreshToken = await _refreshTokenRepository.GetRefreshTokenAsync(refreshTokenDTO.RefreshToken);
                if (storedRefreshToken == null || storedRefreshToken.UserId != userName || storedRefreshToken.ExpiresAt < DateTime.UtcNow)
                {
                    return new LoginReturnDTO { Error = new ErrorBaseDTO { Codigo = "003", Mensagem = $"Refresh token inválido" } };
                }

                // Recupera o usuário associado ao refresh token

                var user = await _userRepository.Obter(storedRefreshToken.UserId);
                if (user == null)
                {
                    return new LoginReturnDTO { Error = new ErrorBaseDTO { Codigo = "002", Mensagem = "Usuario/Senha Invalido." } };
                }
                var refreshReturn = await GenerateToken(user);
                if (refreshReturn == null || refreshReturn.Error != null)
                {
                    return new LoginReturnDTO { Error = new ErrorBaseDTO { Codigo = "002", Mensagem = "Usuario/Senha Invalido." } };
                }

                //Exclui o RefreshToken Anterior
                await _refreshTokenRepository.DeleteRefreshTokenAsync(refreshTokenDTO.RefreshToken);

                return refreshReturn;
            }
            catch (Exception ex)
            {
                return new LoginReturnDTO { Error = new ErrorBaseDTO { Codigo = "001", Mensagem = $"Ocorreu um erro inesperado= {ex.Message}" } };
            }
        }

    }
}
