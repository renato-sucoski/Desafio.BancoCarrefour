using Desafio.BancoCarrefour.Authentication.DAOs;
using Desafio.BancoCarrefour.Authentication.DTOs;
using Desafio.BancoCarrefour.Authentication.Helper;
using Desafio.BancoCarrefour.Authentication.Repository.Interfaces;
using Desafio.BancoCarrefour.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Authentication.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDAO> ValidaLogin(LoginDTO loginDTO)
        {
            var usuario = await _userRepository.Obter(loginDTO.UserName);
            if (usuario == null)
            {
                return null;
            }
            var saltByteTeste = PassHelper.HexStringToByteArray(usuario.Salt);
            var pass = PassHelper.ByteArrayToHexString(PassHelper.GeneratePasswordHash(loginDTO.Password, saltByteTeste));
            if (pass == usuario.Password)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }
    }
}
