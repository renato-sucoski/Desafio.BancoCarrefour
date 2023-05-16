using Microsoft.Extensions.DependencyInjection;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Implementacao;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Interfaces;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Implementacao;

namespace Desafio.BancoCarrefour.FluxoCaixa.Configuracao
{
    public static class FluxoCaixaConfigs
    { 
        public static IServiceCollection ConfigFluxoCaixa(this IServiceCollection services)
        {
            services.AddScoped<ICreditoService, CreditoService>();
            services.AddScoped<IDebitoService, DebitoService>();
            services.AddScoped<ICreditoRepositorio, CreditoRepositorio>();
            services.AddScoped<IDebitoRepositorio, DebitoRepositorio>();
            services.AddScoped<ICreditoRepositorio, CreditoRepositorio>();
            services.AddScoped<IBaseRelatorioService, RelatorioService>();

            return services;
        }
    }
}
