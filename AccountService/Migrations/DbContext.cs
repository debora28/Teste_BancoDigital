using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using AccountService.Models;
using System;

namespace AccountService.Migrations
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options) : base(options)
        {
                Database.EnsureCreated();
            //try
            //{
            //}
            //catch
            //{
            //    Console.WriteLine("Erro na classe ou no DBContext");
            //}
        }

        //Para cada entidade, criar um dbset:
        public DbSet<Conta> Contas { get; set; }

        //Aqui se especifica qual a chave primária e outras definições de banco:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Criando as entidades:
            modelBuilder.Entity<Conta>().HasKey(c => c.IdConta);

            //Alimentando as tabelas (seeding): 
            modelBuilder.Entity<Conta>().HasData(
                new
                {
                    IdConta = 1,
                    ClienteId = 1,
                    CpfCliente = "08995228407",
                    Agencia = "0123",
                    NumConta = 1,
                    Saldo = 0m,
                    Ativa = true,
                    Bloqueada = false,
                    LimiteDiario = 0m
                },
                new
                {
                    IdConta = 2,
                    ClienteId = 2,
                    CpfCliente = "60671150006",
                    Agencia = "0123",
                    NumConta = 2,
                    Saldo = 0m,
                    Ativa = true,
                    Bloqueada = false,
                    LimiteDiario = 0m
                },
                new
                {
                    IdConta = 3,
                    ClienteId = 3,
                    CpfCliente = "47633984074",
                    Agencia = "0123",
                    NumConta = 3,
                    Saldo = 0m,
                    Ativa = true,
                    Bloqueada = false,
                    LimiteDiario = 0m
                });
        }
    }
}
