using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio.BancoCarrefour.FluxoCaixa.DTOs
{
    [Serializable]
    public class CreditoDTO:BaseFluxoDTO
    {
        public string FormaRecebimento { get; set; }
    }
}

