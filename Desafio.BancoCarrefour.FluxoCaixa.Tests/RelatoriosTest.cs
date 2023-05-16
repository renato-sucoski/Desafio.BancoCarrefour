using Desafio.BancoCarrefour.FluxoCaixa.DAOs;
using Desafio.BancoCarrefour.FluxoCaixa.DTOs;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Implementacao;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Desafio.BancoCarrefour.FluxoCaixa.Configuracao;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Desafio.BancoCarrefour.FluxoCaixa.Tests
{
    public class RelatoriosTest
    {
        private ICreditoService _creditoService;
        private IDebitoService _debitoService;
        private IBaseRelatorioService _relatorioService;
        private BaseRepositorio<CreditoDAO> _creditoRepositorio;
        private Context _dbContext;
        private List<CreditoDTO> _dadosCredito;
        private List<DebitoDTO> _dadosDebito;
        [SetUp]
        public void Setup()
        {

            var services = new ServiceCollection();

            services.ConfigFluxoCaixa();
            var serviceProvider = services.AddDbContext<Context>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "TCarrefour.FluxoCaixa").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            }).BuildServiceProvider();
            _dbContext = serviceProvider.GetService<Context>();
            _dbContext.Database.EnsureCreated();
            _creditoService = services.BuildServiceProvider().GetRequiredService<ICreditoService>();
            _debitoService = services.BuildServiceProvider().GetRequiredService<IDebitoService>();
            _relatorioService = services.BuildServiceProvider().GetRequiredService<IBaseRelatorioService>();
        }

        [Test, Order(1)]
        public async Task Valida_Relatorio_Consolidado_Dia_Categoria()
        {
            _dadosCredito = GerarCredito.Registers();
            _dadosDebito = GerarDebito.Registers();
            var resultadoCredito = new List<CreditoRetornoDTO>();
            foreach (var item in _dadosCredito)
            {
                var result = await _creditoService.Inserir(item);
                item.Id = result.Id;
                resultadoCredito.Add(result);
            }
            var resultadoDebito = new List<DebitoRetornoDTO>();
            foreach (var item in _dadosDebito)
            {
                var result = await _debitoService.Inserir(item);
                item.Id = result.Id;
                resultadoDebito.Add(result);
            }

            var resultado = await _relatorioService.RelatorioConsolidadoDiarioCategoria("2023-01-01", "2023-12-31");

            Assert.That(resultado.Data, Has.Count.EqualTo(29));
            Assert.That(resultado.ResultadoPeriodo, Is.EqualTo(174.98M));
            Assert.That(resultado.TotalCreditoPeriodo, Is.EqualTo(2442.00M));
            Assert.That(resultado.TotalDebitoPeriodo, Is.EqualTo(2267.02M));
            Assert.That(resultado.Sucesso, Is.True);
            Assert.That(resultado.Erro, Is.Null);


        }

        [Test, Order(2)]
        public async Task Valida_Relatorio_Consolidado_Dia_FormaPagamento()
        {
            var resultado = await _relatorioService.RelatorioConsolidadoDiarioFormaPagamento("2023-01-01", "2023-12-31");

            Assert.That(resultado.Data, Has.Count.EqualTo(29));
            Assert.That(resultado.ResultadoPeriodo, Is.EqualTo(174.98M));
            Assert.That(resultado.TotalCreditoPeriodo, Is.EqualTo(2442.00M));
            Assert.That(resultado.TotalDebitoPeriodo, Is.EqualTo(2267.02M));
            Assert.That(resultado.Sucesso, Is.True);
            Assert.That(resultado.Erro, Is.Null);
        }


    }
}