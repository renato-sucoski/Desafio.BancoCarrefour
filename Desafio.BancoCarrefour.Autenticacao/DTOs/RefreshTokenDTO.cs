using Microsoft.Extensions.Configuration;
using System;

namespace Desafio.BancoCarrefour.Authentication.DTOs
{
    public class RefreshTokenDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
