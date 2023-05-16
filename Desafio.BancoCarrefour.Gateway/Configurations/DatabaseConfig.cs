using Desafio.BancoCarrefour.Gateway.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Desafio.BancoCarrefour.Gateway.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection ConfigDatabase(this IServiceCollection services)
        {

            services.AddDbContext<Context>(options =>
                options.UseInMemoryDatabase(databaseName: "Carrefour.Gateway"),
                ServiceLifetime.Singleton);

            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<Context>();
            dbContext.Database.EnsureCreated();
            return services;
        }
    }
}
