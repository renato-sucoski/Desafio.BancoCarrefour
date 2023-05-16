using Desafio.BancoCarrefour.FluxoCaixa.DAOs;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Interfaces;


namespace Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Implementacao
{
    public class DebitoRepositorio : BaseRepositorio<DebitoDAO>, IDebitoRepositorio
    {
        public DebitoRepositorio(Context dbContext) : base(dbContext)
        {
        }


    }
}
