using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.BancoCarrefour.FluxoCaixa.DAOs
{
    [Serializable]
    public class CreditoDAO : BaseFluxoDAO
    {
        [Required(ErrorMessage = "Campo FormaRecebimento é obrigatório.")]
        public string FormaRecebimento { get; set; }
    }
}
