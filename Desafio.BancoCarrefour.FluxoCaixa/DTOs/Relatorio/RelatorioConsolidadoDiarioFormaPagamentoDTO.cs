using System.Collections.Generic;

namespace Desafio.BancoCarrefour.FluxoCaixa.DTOs.Relatorio
{
    public class RelatorioConsolidadoDiarioFormaPagamentoDTO 
    {
        public List<DataConsolidadoDTO<ValorFormaPagamentoCreditoDTO,ValorFormaPagamentoDebitoDTO>> Data { get; set; }
        public decimal TotalCreditoPeriodo { get; set; }
        public decimal TotalDebitoPeriodo { get; set; }
        public decimal ResultadoPeriodo { get; set; }
        public bool Sucesso { get; set; }
        public ErrorBaseDTO Erro { get; set; }
    }
}
