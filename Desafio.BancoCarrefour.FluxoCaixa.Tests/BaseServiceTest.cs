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
    public class BaseServiceTest
    {
        private ICreditoService _creditoService;
        private BaseRepositorio<CreditoDAO> _creditoRepositorio;
        private Context _dbContext;
        private List<CreditoDTO> _dados;
        private List<CreditoDTO> _dadosComparacao;
        [SetUp]
        public void Setup()
        {
            if (_dados == null)
            {
                _dados = new List<CreditoDTO>
                {
                    new CreditoDTO
                    {
                        DataHoraLancamentoUTC = DateTime.UtcNow.AddMinutes(2),
                        Descricao = "Agua Mineral Alba 500 ml",
                        FormaRecebimento = "Dinheiro",
                        UsuarioLancamento = "ADM",
                        Valor = 5.13m,
                        CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a"

                    },
                    new CreditoDTO
                    {
                        DataHoraLancamentoUTC = DateTime.UtcNow.AddDays(2),
                        Descricao = "Bartender - Serviço temporário",
                        FormaRecebimento = "Dinheiro",
                        UsuarioLancamento = "ADM",
                        Valor = 2.13m,
                        CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0"
                    },
                    new CreditoDTO
                    {
                        DataHoraLancamentoUTC = DateTime.UtcNow.AddDays(5),
                        Descricao = "Cerveja Spaten 600 ml",
                        FormaRecebimento = "Cartão de Débito",
                        UsuarioLancamento = "ADM",
                        Valor = 7.99m,
                        CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a"
                    },
                    new CreditoDTO
                    {
                        DataHoraLancamentoUTC = DateTime.UtcNow.AddDays(5),
                        Descricao = "Locar carro para pessoa Fisica - UNO",
                        FormaRecebimento = "Cartão de Débito",
                        UsuarioLancamento = "ADM",
                        Valor = 7.99m,
                        CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a"
                    }
                };
            }

            var services = new ServiceCollection();

            services.ConfigFluxoCaixa();
            var serviceProvider = services.AddDbContext<Context>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "TCarrefour.FluxoCaixa").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            }).BuildServiceProvider();
            _dbContext = serviceProvider.GetService<Context>();
            _dbContext.Database.EnsureCreated();
            _creditoService = services.BuildServiceProvider().GetRequiredService<ICreditoService>();
        }

        [Test, Order(1)]
        public async Task Inserir_Deve_Inserir_Um_a_Um_os_4_registros()
        {
            var resultado = new List<CreditoRetornoDTO>();
            foreach (var item in _dados)
            {
                resultado.Add(await _creditoService.Inserir(item));
            }
            resultado = resultado.OrderBy(x => x.Descricao).ToList();

            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado, Has.Count.EqualTo(4));
            for (var i = 0; i < resultado.Count; i++)
            {
                Assert.That(resultado[i].Descricao, Is.EqualTo(_dados[i].Descricao));
                Assert.That(resultado[i].Valor, Is.EqualTo(_dados[i].Valor));
                Assert.That(resultado[i].DataHoraLancamentoUTC, Is.EqualTo(_dados[i].DataHoraLancamentoUTC));
                Assert.That(resultado[i].UsuarioLancamento, Is.EqualTo(_dados[i].UsuarioLancamento));
                Assert.That(resultado[i].FormaRecebimento, Is.EqualTo(_dados[i].FormaRecebimento));
                Assert.That(resultado[i].CategoriaId, Is.EqualTo(_dados[i].CategoriaId));
                _dados[i].Id = resultado[i].Id;
            }
        }


        [Test, Order(2)]
        public async Task Obter_Deve_Retornar_Entidade_Correta()
        {
            var categorias = _dbContext.Categoria.ToList();
            var resultado = await _creditoService.Obter(_dados[1].Id);

            
            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado.Categoria, Is.Not.Null);  
            Assert.That(resultado.Id, Is.EqualTo(_dados[1].Id));
            Assert.That(resultado.Descricao, Is.EqualTo(_dados[1].Descricao));
            Assert.That(resultado.Valor, Is.EqualTo(_dados[1].Valor));
            Assert.That(resultado.DataHoraLancamentoUTC, Is.EqualTo(_dados[1].DataHoraLancamentoUTC));
            Assert.That(resultado.UsuarioLancamento, Is.EqualTo(_dados[1].UsuarioLancamento));
            Assert.That(resultado.FormaRecebimento, Is.EqualTo(_dados[1].FormaRecebimento));
            Assert.That(resultado.CategoriaId, Is.EqualTo(_dados[1].CategoriaId));
            Assert.That(resultado.Categoria.Id, Is.EqualTo(_dados[1].CategoriaId));
        }

        [Test, Order(3)]
        public async Task Obter_Deve_Retornar_Lista_De_Entidades_Corretas()
        {

            var resultado = await _creditoService.ObterTodos();
            resultado = resultado.OrderBy(x => x.Descricao).ToList();

            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado, Has.Count.EqualTo(4));
            for (var i = 0; i < resultado.Count; i++)
            {
                Assert.That(resultado[i].Descricao, Is.EqualTo(_dados[i].Descricao));
                Assert.That(resultado[i].Valor, Is.EqualTo(_dados[i].Valor));
                Assert.That(resultado[i].DataHoraLancamentoUTC, Is.EqualTo(_dados[i].DataHoraLancamentoUTC));
                Assert.That(resultado[i].UsuarioLancamento, Is.EqualTo(_dados[i].UsuarioLancamento));
                Assert.That(resultado[i].FormaRecebimento, Is.EqualTo(_dados[i].FormaRecebimento));
                Assert.That(resultado[i].CategoriaId, Is.EqualTo(_dados[i].CategoriaId));
                Assert.That(resultado[i].Id, Is.EqualTo(_dados[i].Id));
            }
        }

        [Test, Order(4)]
        public async Task Atualizar_Deve_Atualizar_Corretamente_A_Entidade()
        {
            var atualizar = _dados[0];
            atualizar.Descricao = "Agua Mineral Alba 700 ml";
            var resultado = await _creditoService.Atualizar(atualizar);

            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado.Erros, Is.Null);
            Assert.That(resultado.Sucesso, Is.True);

            var obter = await _creditoService.Obter(atualizar.Id);
            Assert.That(obter, Is.Not.Null);
            Assert.That(obter.Erros, Is.Null);
            Assert.That(obter.Id, Is.EqualTo(_dados[0].Id));
            Assert.That(obter.Descricao, Is.EqualTo(_dados[0].Descricao));
            Assert.That(obter.Valor, Is.EqualTo(_dados[0].Valor));
            Assert.That(obter.DataHoraLancamentoUTC, Is.EqualTo(_dados[0].DataHoraLancamentoUTC));
            Assert.That(obter.UsuarioLancamento, Is.EqualTo(_dados[0].UsuarioLancamento));
            Assert.That(obter.FormaRecebimento, Is.EqualTo(_dados[0].FormaRecebimento));
            Assert.That(obter.CategoriaId, Is.EqualTo(_dados[0].CategoriaId));
        }
        [Test, Order(5)]
        public async Task PesquisarPorData_Deve_Trazer_Entidades1e2_De_Um_Range_De_Datas()
        {

            var inicio = _dados[0].DataHoraLancamentoUTC.ToLocalTime();
            var fim = _dados[1].DataHoraLancamentoUTC.ToLocalTime();
            var dataInicio = inicio.ToString("yyyy-MM-dd");
            var dataFim = fim.ToString("yyyy-MM-dd");
            var resultado = await _creditoService.PesquisarPorData(dataInicio, dataFim);
            resultado = resultado.OrderBy(x => x.Descricao).ToList();

            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado, Has.Count.EqualTo(2));
            for (var i = 0; i < resultado.Count; i++)
            {
                Assert.That(resultado[i].Descricao, Is.EqualTo(_dados[i].Descricao));
                Assert.That(resultado[i].Valor, Is.EqualTo(_dados[i].Valor));
                Assert.That(resultado[i].DataHoraLancamentoUTC, Is.EqualTo(_dados[i].DataHoraLancamentoUTC));
                Assert.That(resultado[i].UsuarioLancamento, Is.EqualTo(_dados[i].UsuarioLancamento));
                Assert.That(resultado[i].FormaRecebimento, Is.EqualTo(_dados[i].FormaRecebimento));
                Assert.That(resultado[i].CategoriaId, Is.EqualTo(_dados[i].CategoriaId));
                Assert.That(resultado[i].Id, Is.EqualTo(_dados[i].Id));
            }

        }
        [Test, Order(6)]
        public async Task PesquisarPorDescricao_Deve_Trazer_Entidades1e3_Por_Parte_Da_Descricao()
        {

            var resultado = await _creditoService.PesquisarPorDescricao("ml");
            resultado = resultado.OrderBy(x => x.Descricao).ToList();

            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado, Has.Count.EqualTo(2));

            Assert.That(resultado[0].Descricao, Is.EqualTo(_dados[0].Descricao));
            Assert.That(resultado[0].Valor, Is.EqualTo(_dados[0].Valor));
            Assert.That(resultado[0].DataHoraLancamentoUTC, Is.EqualTo(_dados[0].DataHoraLancamentoUTC));
            Assert.That(resultado[0].UsuarioLancamento, Is.EqualTo(_dados[0].UsuarioLancamento));
            Assert.That(resultado[0].FormaRecebimento, Is.EqualTo(_dados[0].FormaRecebimento));
            Assert.That(resultado[0].Id, Is.EqualTo(_dados[0].Id));

            Assert.That(resultado[1].Descricao, Is.EqualTo(_dados[2].Descricao));
            Assert.That(resultado[1].Valor, Is.EqualTo(_dados[2].Valor));
            Assert.That(resultado[1].DataHoraLancamentoUTC, Is.EqualTo(_dados[2].DataHoraLancamentoUTC));
            Assert.That(resultado[1].UsuarioLancamento, Is.EqualTo(_dados[2].UsuarioLancamento));
            Assert.That(resultado[1].FormaRecebimento, Is.EqualTo(_dados[2].FormaRecebimento));
            Assert.That(resultado[1].CategoriaId, Is.EqualTo(_dados[2].CategoriaId));
            Assert.That(resultado[1].Id, Is.EqualTo(_dados[2].Id));

        }

        [Test, Order(7)]
        public async Task Excluir_Deve_Excluir_Corretamente_A_Entidade()
        {
            var resultado = await _creditoService.Excluir(_dados[2].Id);

            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado.Erros, Is.Null);
            Assert.That(resultado.Sucesso, Is.True);
        }

        [Test, Order(8)]
        public async Task Obter_Deve_Retornar_Erro_Registro_Foi_Excluido()
        {
            var obter = await _creditoService.Obter(_dados[2].Id);
            Assert.That(obter, Is.Not.Null);
            Assert.That(obter.Erros, Is.Not.Null);
            Assert.That(obter.Erros[0].Codigo, Is.EqualTo("010"));
            Assert.That(obter.Erros[0].Mensagem, Is.EqualTo("Registro não encontrado."));
        }
        [Test, Order(9)]
        public async Task Obter_Deve_Retornar_Erro_Id_Invalido()
        {
            var obter = await _creditoService.Obter("");
            Assert.That(obter, Is.Not.Null);
            Assert.That(obter.Erros, Is.Not.Null);
            Assert.That(obter.Erros[0].Codigo, Is.EqualTo("001"));
            Assert.That(obter.Erros[0].Mensagem, Is.EqualTo("Ocorreu um erro: Id inválido."));
        }
    }
}