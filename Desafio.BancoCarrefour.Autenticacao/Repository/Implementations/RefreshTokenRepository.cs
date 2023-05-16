using Desafio.BancoCarrefour.Authentication.DAOs;
using Desafio.BancoCarrefour.Authentication.DTOs;
using Desafio.BancoCarrefour.Authentication.Repositorio;
using Desafio.BancoCarrefour.Authentication.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Authentication.Repository.Implementations
{

    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly Context _context;

        public RefreshTokenRepository(Context context)
        {
            _context = context;
        }

        public async Task SaveRefreshTokenAsync(RefreshTokenDAO refreshToken)
        {
            await _context.RefreshToken.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }
        public async Task<RefreshTokenDAO> GetRefreshTokenAsync(string token)
        {
            return await _context.RefreshToken.SingleOrDefaultAsync(rt => rt.Token == token);
        }
        public async Task DeleteRefreshTokenAsync(string token)
        {
            var refreshToken = await GetRefreshTokenAsync(token);

            if (refreshToken != null)
            {
                _context.RefreshToken.Remove(refreshToken);
                await _context.SaveChangesAsync();
            }
        }
    }
}
