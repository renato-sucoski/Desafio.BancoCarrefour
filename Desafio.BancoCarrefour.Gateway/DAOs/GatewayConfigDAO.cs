using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Desafio.BancoCarrefour.Gateway.DAOs
{
    [Table("GatewayConfig")]
    public class GatewayConfigDAO
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string CaminhoLocal { get; set; }
        [Required]
        public string URLRedirecionar { get; set; }
        [Required]
        public string Metodo { get; set; }
        [Required]
        public string Roles { get; set; }

    }
}
