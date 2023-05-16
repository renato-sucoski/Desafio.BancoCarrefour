using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;

namespace Desafio.BancoCarrefour.Authentication.Helper
{
    public static class TokenHelper
    {
        public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration configuration)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, // Você pode definir essa propriedade para validar a audiência do token, se necessário
                ValidateIssuer = false, // Você pode definir essa propriedade para validar o emissor do token, se necessário
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AuthSecret"))),
                ValidateLifetime = false // Não valide a expiração do token aqui, pois já estamos lidando com um token expirado
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            // Validar o token JWT
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Token inválido");
            }

            return principal;
        }
    }
}
