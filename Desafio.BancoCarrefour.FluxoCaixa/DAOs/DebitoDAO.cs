using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.BancoCarrefour.FluxoCaixa.DAOs
{
    public class DebitoDAO : BaseFluxoDAO
    {
        [Required(ErrorMessage = "Campo FormaPagamento é obrigatório.")]
        public string FormaPagamento { get; set; }
    }
}
