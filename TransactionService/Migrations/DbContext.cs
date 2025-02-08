using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using TransactionService.Models;

namespace TransactionService.Migrations
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
        //public DbSet<Conta> Contas { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }

        //Aqui se especifica qual a chave primária e outras definições de banco:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Criando as entidades:
            modelBuilder.Entity<Operacao>().HasKey(c => c.IdOperacao);

            //Alimentando as tabelas (seeding): 
           
            modelBuilder.Entity<Operacao>().HasData(
            new
            {
                IdOperacao = 1,
                TipoOperacao = "Depósito",
                DataOperacao = new DateTime(),
                //Versao = 1,
                Valor = 8798.13m,
                IdConta = 1
            },
            new
            {
                IdOperacao = 2,
                TipoOperacao = "Saque",
                DataOperacao = new DateTime(),
                //Versao = 1,
                Valor = 452.17m,
                IdConta = 1
            }
            );
        }
    }
}
