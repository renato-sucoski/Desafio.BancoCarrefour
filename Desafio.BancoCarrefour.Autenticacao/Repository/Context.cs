using Desafio.BancoCarrefour.Authentication.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace Desafio.BancoCarrefour.Authentication.Repositorio
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<RoleDAO>().HasData(
                new RoleDAO { Id = "63919430-5681-4293-a079-0bdda0a6b47d", RoleName = "AdmSistema" },
                new RoleDAO { Id = "6ca404df-827e-4332-aa22-e909721790b0", RoleName = "Credito" },
                new RoleDAO { Id = "89cf6df1-0347-4438-9f04-d60de82693a1", RoleName = "Debito" },
                new RoleDAO { Id = "3d5c66de-d5f8-4413-ba37-638090e344d5", RoleName = "Gerencial" }
            );

            modelBuilder.Entity<UserDAO>().HasData(
                new UserDAO
                {
                    Id = "e6318fe9-262b-4b71-ad3b-05d4cc127832",
                    Email = "sysadmin@emailteste.com.br",
                    FirstName = "Administrator",
                    LastName = "System",
                    Password = "57d9a52b03ed34a3ea60dac910c37a1fae9f0ad0994e5bdae1ae0440a3fda7fc", //Senha: Papa32%45TK
                    Salt = "45fdd714591dd431b5adf925c01701c4",
                    UserName = "SystemAdmin",
                    RoleId = "63919430-5681-4293-a079-0bdda0a6b47d"
                },
                new UserDAO
                {
                    Id = "d32cae03-3812-48a7-87af-8513e7991faf",
                    Email = "scredito@emailteste.com.br",
                    FirstName = "Setor",
                    LastName = "Credito",
                    Password = "31c807a9a761c2e733245f75ebd614a5323effe9ba625c6b523302fb3f1d4946", //Senha: oLary%K2k*
                    Salt = "87fe105758ab4685d145e236f6e47034",
                    UserName = "SCredito",
                    RoleId = "6ca404df-827e-4332-aa22-e909721790b0"
                },
                new UserDAO
                {
                    Id = "7f9067d4-8a67-449e-96aa-5b9ce54e77f6",
                    Email = "scredito@emailteste.com.br",
                    FirstName = "Setor",
                    LastName = "Debito",
                    Password = "13c8a3ed032810130637327852b5eedbf6170a44d51e1f016a0138ae65f9fada", //Senha: posKj*66&dj
                    Salt = "c59b8a59723db2b140e62b0a6342bbc1",
                    UserName = "SDebito",
                    RoleId = "89cf6df1-0347-4438-9f04-d60de82693a1"
                },
                new UserDAO
                {
                    Id = "7f005d5b-8ea8-41cc-b21f-81623b73461c",
                    Email = "manager@emailteste.com.br",
                    FirstName = "Usuario",
                    LastName = "Gerencial",
                    Password = "700d6e9ef0b48e21e6e6ba2b2e4617507b425c1e351062445fbab76f2cc1a8fe", //Senha: Papa32%45TK
                    Salt = "d3001355109200566603fee36fb43e06",
                    UserName = "ManagerUser",
                    RoleId = "3d5c66de-d5f8-4413-ba37-638090e344d5"
                }

            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<RoleDAO> Role { get; set; }
        public DbSet<UserDAO> User { get; set; }
        public DbSet<RefreshTokenDAO> RefreshToken { get; set; }
    }
}
