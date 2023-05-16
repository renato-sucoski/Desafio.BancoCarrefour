using Desafio.BancoCarrefour.FluxoCaixa.DAOs;
using Desafio.BancoCarrefour.FluxoCaixa.DTOs;

namespace Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces
{
    public interface IDebitoService : IBaseService<DebitoDTO, DebitoRetornoDTO, DebitoDAO>
    {

    }
}
