using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios;

namespace Desafio.BancoCarrefour.FluxoCaixa.Configuracao
{
    public static class DatabaseConfig
    {
        public static IServiceCollection ConfigDatabase(this IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                  options.UseInMemoryDatabase(databaseName: "Carrefour.FluxoCaixa"),
                  ServiceLifetime.Singleton);

            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<Context>();
            dbContext.Database.EnsureCreated();
            return services;
        }
    }
}
