using Desafio.BancoCarrefour.Gateway.DAOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Gateway.Repository.Interfaces
{
    public interface IGatewayRepository
    {
        Task<List<GatewayConfigDAO>> ObterTodos();
    }
}
