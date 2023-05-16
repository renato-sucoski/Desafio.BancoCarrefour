using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Desafio.BancoCarrefour.FluxoCaixa.DTOs.Relatorio
{
    public class DataConsolidadoDTO<TCred,TDeb>
    {
        public string Data { get; set; }
        public decimal TotalCredito { get; set; }
        public decimal TotalDebito { get; set; }
        public decimal ResultadoDia { get; set; }
        public List<TCred> DadosCredito { get; set; }
        public List<TDeb> DadosDebito { get; set; }
    }
}
