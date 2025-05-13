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
            try
            {
                Database.EnsureCreated();
            }
            catch
            {
                Console.WriteLine("Erro na classe ou no DBContext");
            }
        }

        public DbSet<Operacao> Operacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operacao>().HasKey(c => c.IdOperacao);

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
