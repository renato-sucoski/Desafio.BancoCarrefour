using Desafio.BancoCarrefour.Authentication.DAOs;
using Desafio.BancoCarrefour.Authentication.Repositorio;
using Desafio.BancoCarrefour.Authentication.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Authentication.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }
        public async Task<UserDAO> Obter(string userName)
        {
            var usuario = await _context.User.Where(x => x.UserName == userName).Include(x => x.Role).SingleOrDefaultAsync();
            //?? throw new Exception("Usuário não encontrado");
            var teste = await _context.User.ToListAsync();
            return usuario;
        }
    }
}
