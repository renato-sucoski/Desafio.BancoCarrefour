using Desafio.BancoCarrefour.FluxoCaixa.DAOs;
using Desafio.BancoCarrefour.FluxoCaixa.DTOs;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Interfaces;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces;

namespace Desafio.BancoCarrefour.FluxoCaixa.Services.Implementacao
{
    public class CreditoService : BaseService<CreditoDTO, CreditoRetornoDTO, CreditoDAO>, ICreditoService
    {
        public CreditoService(ICreditoRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
