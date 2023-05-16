using Desafio.BancoCarrefour.FluxoCaixa.DTOs.Relatorio;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces
{
    public interface IBaseRelatorioService
    {
        Task<RelatorioConsolidadoDiarioCategoriaDTO> RelatorioConsolidadoDiarioCategoria(string dataInicio, string dataFim);
        Task<RelatorioConsolidadoDiarioFormaPagamentoDTO> RelatorioConsolidadoDiarioFormaPagamento(string dataInicio, string dataFim);
    }
}
