using Desafio.BancoCarrefour.FluxoCaixa.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.BancoCarrefour.FluxoCaixa.DAOs
{
    [Serializable]
    public class BaseFluxoDAO
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Campo DataHoraLancamento é obrigatório.")]
        public DateTime DataHoraLancamentoUTC { get; set; }

        [Required(ErrorMessage = "Campo UsuarioLancamento é obrigatório.")]
        public string UsuarioLancamento { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Categoria é obrigatório.")]
        public string CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo Valor é obrigatório.")]
        public decimal Valor { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual CategoriaDAO Categoria { get; set; }

    }
}
