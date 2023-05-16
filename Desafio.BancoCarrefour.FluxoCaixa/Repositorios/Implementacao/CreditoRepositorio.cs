using Desafio.BancoCarrefour.FluxoCaixa.DAOs;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Interfaces;


namespace Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Implementacao
{
    public class CreditoRepositorio : BaseRepositorio<CreditoDAO>, ICreditoRepositorio
    {
        public CreditoRepositorio(Context dbContext) : base(dbContext)
        {
        }

    }
}
