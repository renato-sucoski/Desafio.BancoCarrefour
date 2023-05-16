using Desafio.BancoCarrefour.Authentication.DAOs;
using Desafio.BancoCarrefour.Authentication.DTOs;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Authentication.Services.Interfaces
{
    public interface ITokenService
    {
        Task<LoginReturnDTO> GenerateToken(LoginDTO loginDTO);
        Task<LoginReturnDTO> GenerateToken(UserDAO user);
        Task<RefreshTokenDAO> GenerateRefreshToken(string userId);
        Task<LoginReturnDTO> RefreshToken(RefreshTokenDTO refreshTokenDTO);
    }
}
