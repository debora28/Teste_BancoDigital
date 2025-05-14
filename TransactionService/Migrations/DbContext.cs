using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using TransactionService.Models;

namespace TransactionService.Migrations
{
    public class Bank01Context : DbContext
    {
        public Bank01Context(DbContextOptions options) : base(options)
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

        public DbSet<TypeTransaction> TypeTransaction { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>().HasKey(c => c.TransactionId);

            modelBuilder.Entity<Transaction>().HasData(
            new
            {
                TransactionId = 2,
                TransactionDate = new DateTime(),
                Amount = 8798.13m,
                AccountId = 1,
                TypeTransactionId = 1
            },
            new
            {
                TransactionId = 1,
                TransactionDate = new DateTime(),
                Amount = 8798.13m,
                AccountId = 1,
                TypeTransactionId = 1
            }
            );

            modelBuilder.Entity<TypeTransaction>().HasKey(c => c.TypeTransactionId);
            modelBuilder.Entity<TypeTransaction>().HasData(
                new { TypeTransactionId = 1, TypeTransactionName = "Depósito" },
                new { TypeTransactionId = 2, TypeTransactionName = "Saque" },
                new { TypeTransactionId = 3, TypeTransactionName = "Saldo" },
                new { TypeTransactionId = 4, TypeTransactionName = "Pix" },
                new { TypeTransactionId = 5, TypeTransactionName = "Transferência" },
                new { TypeTransactionId = 6, TypeTransactionName = "Pagamento" },
                new { TypeTransactionId = 7, TypeTransactionName = "Recarga de Celular" },
                new { TypeTransactionId = 8, TypeTransactionName = "Comprovantes" },
                new { TypeTransactionId = 9, TypeTransactionName = "Extrato Simples" },
                new { TypeTransactionId = 10, TypeTransactionName = "Extrato por Período" },
                new { TypeTransactionId = 11, TypeTransactionName = "Bloqueio de Conta" },
                new { TypeTransactionId = 12, TypeTransactionName = "Desbloqueio de Conta" },
                new { TypeTransactionId = 13, TypeTransactionName = "Alteração de Limite Diário" },
                new { TypeTransactionId = 14, TypeTransactionName = "Cancelamento de Conta" }
            );
        }
    }
}
