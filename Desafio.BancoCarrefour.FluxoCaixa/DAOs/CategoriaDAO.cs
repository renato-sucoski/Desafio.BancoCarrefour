using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.BancoCarrefour.FluxoCaixa.DAOs
{
    [Table("Categoria")]
    public class CategoriaDAO
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Descricao { get; set; }


        
    }
}
