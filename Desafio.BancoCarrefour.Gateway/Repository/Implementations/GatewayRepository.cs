using Desafio.BancoCarrefour.Gateway.DAOs;
using Desafio.BancoCarrefour.Gateway.Repositorio;
using Desafio.BancoCarrefour.Gateway.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Gateway.Repository.Implementations
{
    public class GatewayRepository : IGatewayRepository
    {
        private readonly Context _dbContext;

        public GatewayRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<GatewayConfigDAO>> ObterTodos()
        {
            return await _dbContext.GatewayConfig.ToListAsync();
        }
    }
}
