using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Desafio.BancoCarrefour.Gateway.Helper
{
    public static class JwtHelper
    {
        public static RetJWT TryDecodeJwt(string token, string secretKey)
        {
            // Configurar as opções de validação do token
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false, // Verificar o emissor do token (opcional)
                ValidateAudience = false, // Verificar a audiência do token (opcional)
                ValidateLifetime = false, // Verificar a validade do token (opcional)
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) // Configurar a chave secreta usada para assinar o token
            };

            // Validar e ler o token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

            // Obter as informações do token JWT
            var jwtTokenInfo = (JwtSecurityToken)validatedToken;
            var userId = jwtTokenInfo.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var roles = jwtTokenInfo.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            var expir = jwtTokenInfo.Claims.Where(c => c.Type == "exp").Select(c => c.Value).FirstOrDefault();
            return new RetJWT { Exp = expir, Roles = roles, Sub = userId };

        }
        public class RetJWT
        {

            public string Sub { get; set; }
            public string Jti { get; set; }
            public List<string> Roles { get; set; }
            public string Exp { get; set; }
            public string Iss { get; set; }
            public string Aud { get; set; }


        }
    }
}
