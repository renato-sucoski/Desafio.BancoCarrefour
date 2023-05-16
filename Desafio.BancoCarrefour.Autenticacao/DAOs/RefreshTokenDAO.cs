using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.BancoCarrefour.Authentication.DAOs
{
    [Table("RefreshToken")]
    public class RefreshTokenDAO
    {
        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string UserId { get; set; }
    }
}
