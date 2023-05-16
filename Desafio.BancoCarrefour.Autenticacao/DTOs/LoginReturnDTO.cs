using System;

namespace Desafio.BancoCarrefour.Authentication.DTOs
{
    public class LoginReturnDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public ErrorBaseDTO Error { get; set; }

    }
}
