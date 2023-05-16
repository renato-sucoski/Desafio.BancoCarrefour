using Desafio.BancoCarrefour.Authentication.DAOs;
using Desafio.BancoCarrefour.Authentication.DTOs;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Authentication.Repository.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task SaveRefreshTokenAsync(RefreshTokenDAO refreshToken);
        Task<RefreshTokenDAO> GetRefreshTokenAsync(string token);
        Task DeleteRefreshTokenAsync(string token);
    }
}
