
using Desafio.BancoCarrefour.Gateway.DAOs;
using Microsoft.EntityFrameworkCore;

namespace Desafio.BancoCarrefour.Gateway.Repositorio
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de modelo aqui...
            //"AdmSistema"
 //"Credito" },
 //"Debito" },
 //"Gerencial" }
modelBuilder.Entity<GatewayConfigDAO>().HasData(
                new GatewayConfigDAO { Id = "63919430-5681-4293-a079-0bdda0a6b471", CaminhoLocal = "/api/Credito/Inserir", URLRedirecionar = "http://localhost:48734/api/Credito/Inserir", Roles = "AdmSistema,Credito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "6ca404df-827e-4332-aa22-e909721790b2", CaminhoLocal = "/api/Credito/Atualizar", URLRedirecionar = "http://localhost:48734/api/Credito/Atualizar", Roles = "AdmSistema,Credito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "89cf6df1-0347-4438-9f04-d60de82693a3", CaminhoLocal = "/api/Credito/Excluir", URLRedirecionar = "http://localhost:48734/api/Credito/Excluir", Roles = "AdmSistema,Credito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e344d4", CaminhoLocal = "/api/Credito/Obter", URLRedirecionar = "http://localhost:48734/api/Credito/Obter", Roles = "AdmSistema,Credito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e344d5", CaminhoLocal = "/api/Credito/ObterTodos", URLRedirecionar = "http://localhost:48734/api/Credito/ObterTodos", Roles = "AdmSistema,Credito", Metodo = "Get" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e344d6", CaminhoLocal = "/api/Credito/PesquisarPorData", URLRedirecionar = "http://localhost:48734/api/Credito/PesquisarPorData", Roles = "AdmSistema,Credito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e344d7", CaminhoLocal = "/api/Credito/PesquisarPorDescricao", URLRedirecionar = "http://localhost:48734/api/Credito/PesquisarPorDescricao", Roles = "AdmSistema,Credito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "63919430-5681-4293-a079-0bdda0a6b478", CaminhoLocal = "/api/Debito/Inserir", URLRedirecionar = "http://localhost:48734/api/Debito/Inserir", Roles = "AdmSistema,Debito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "6ca404df-827e-4332-aa22-e909721790b9", CaminhoLocal = "/api/Debito/Atualizar", URLRedirecionar = "http://localhost:48734/api/Debito/Atualizar", Roles = "AdmSistema,Debito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "89cf6df1-0347-4438-9f04-d60de8269310", CaminhoLocal = "/api/Debito/Excluir", URLRedirecionar = "http://localhost:48734/api/Debito/Excluir", Roles = "AdmSistema,Debito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e34411", CaminhoLocal = "/api/Debito/Obter", URLRedirecionar = "http://localhost:48734/api/Debito/Obter", Roles = "AdmSistema,Debito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e34412", CaminhoLocal = "/api/Debito/ObterTodos", URLRedirecionar = "http://localhost:48734/api/Debito/ObterTodos", Roles = "AdmSistema,Debito", Metodo = "Get" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e34413", CaminhoLocal = "/api/Debito/PesquisarPorData", URLRedirecionar = "http://localhost:48734/api/Debito/PesquisarPorData", Roles = "AdmSistema,Debito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e34414", CaminhoLocal = "/api/Debito/PesquisarPorDescricao", URLRedirecionar = "http://localhost:48734/api/Debito/PesquisarPorDescricao", Roles = "AdmSistema,Debito", Metodo = "Post" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e34423", CaminhoLocal = "/api/Relatorio/RelatorioCategoria", URLRedirecionar = "http://localhost:48734/api/Relatorio/RelatorioCategoria", Roles = "AdmSistema,Gerencial", Metodo = "Post" },
                new GatewayConfigDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e34424", CaminhoLocal = "/api/Relatorio/RelatorioFormaPagamento", URLRedirecionar = "http://localhost:48734/api/Relatorio/RelatorioFormaPagamento", Roles = "AdmSistema,Gerencial", Metodo = "Post" }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GatewayConfigDAO> GatewayConfig { get; set; }
    }
}
