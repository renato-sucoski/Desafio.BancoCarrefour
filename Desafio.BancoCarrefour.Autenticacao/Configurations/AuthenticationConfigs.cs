using Desafio.BancoCarrefour.Authentication.DAOs;
using Desafio.BancoCarrefour.Authentication.Repository.Implementations;
using Desafio.BancoCarrefour.Authentication.Repository.Interfaces;
using Desafio.BancoCarrefour.Authentication.Services.Implementations;
using Desafio.BancoCarrefour.Authentication.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.BancoCarrefour.Authentication.Configurations
{
    public static class AuthenticationConfigs
    {
        public static IServiceCollection ConfigAuthentication(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
