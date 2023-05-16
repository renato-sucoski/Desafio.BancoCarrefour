using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Desafio.BancoCarrefour.FluxoCaixa.DAOs;


namespace Desafio.BancoCarrefour.FluxoCaixa.Repositorios
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CategoriaDAO>().HasData(
                new CategoriaDAO { Id = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a", Descricao = "Venda" },
                new CategoriaDAO { Id = "389975e6-b700-40a8-9db5-d466a0a3c10a", Descricao = "Compra" },
                new CategoriaDAO { Id = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f", Descricao = "Locação" },
                new CategoriaDAO { Id = "5a42c095-7e73-4069-855a-c80c05b925b0", Descricao = "Serviço" }
            );
        }
        // Definir as entidades como DbSet<T> aqui
        public DbSet<CreditoDAO> Credito { get; set; }
        public DbSet<DebitoDAO> Debito { get; set; }
        public DbSet<CategoriaDAO> Categoria { get; set; }
    }
}
