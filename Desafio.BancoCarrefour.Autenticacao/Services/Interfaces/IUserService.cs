using Desafio.BancoCarrefour.Authentication.DAOs;
using Desafio.BancoCarrefour.Authentication.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Authentication.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDAO> ValidaLogin(LoginDTO loginDTO);
    }
}
