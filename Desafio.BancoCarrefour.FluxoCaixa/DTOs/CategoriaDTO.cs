using System.ComponentModel.DataAnnotations;

namespace Desafio.BancoCarrefour.FluxoCaixa.DTOs
{
    public class CategoriaDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
