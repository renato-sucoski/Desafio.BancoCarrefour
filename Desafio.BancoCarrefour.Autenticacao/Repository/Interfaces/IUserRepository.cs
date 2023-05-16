using Desafio.BancoCarrefour.Authentication.DAOs;
using Desafio.BancoCarrefour.Authentication.DTOs;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Authentication.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDAO> Obter(string userName);
    }
}
