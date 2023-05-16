using Desafio.BancoCarrefour.FluxoCaixa.DAOs;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Interfaces;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces;
using Desafio.BancoCarrefour.FluxoCaixa.DTOs;

namespace Desafio.BancoCarrefour.FluxoCaixa.Services.Implementacao
{
    public class DebitoService : BaseService<DebitoDTO, DebitoRetornoDTO, DebitoDAO>, IDebitoService
    {
        public DebitoService(IDebitoRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
