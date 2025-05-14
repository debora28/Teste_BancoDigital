using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using AccountService.Models;
using System;
using Microsoft.Identity.Client;

namespace AccountService.Migrations
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
                Console.WriteLine("Erro na classe ou no DBContext do Bank01");
            }
        }

        public DbSet<Status> Status { get; set; }
        public DbSet<Account> Account { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Status>().HasKey(c => c.StatusId);

            modelBuilder.Entity<Status>().HasData(
                new
                {
                    StatusId = 1,
                    StatusName = "Ativo"
                },
                new
                {
                    StatusId = 2,
                    StatusName = "Bloqueado"
                },
                new
                {
                    StatusId = 3,
                    StatusName = "Desbloqueado"
                },
                new
                {
                    StatusId = 4,
                    StatusName = "Fechado"
                },
                new
                {
                    StatusId = 5,
                    StatusName = "Cancelado"
                });
            modelBuilder.Entity<Account>().HasKey(c => c.AccountId);

            modelBuilder.Entity<Account>().HasData(
                new
                {
                    AccountId = 1,
                    AccountType = "Corrente",
                    Agency = "7460",
                    AccountNumber = "7460",
                    DateOpened = DateTime.Now,
                    DateClosed = DateTime.Now,
                    DailyLimit = 2000m,
                    ClientId = 1,
                    StatusId = 1
                },
                new
                {
                    AccountId = 2,
                    AccountType = "Poupança",
                    Agency = "7460",
                    AccountNumber = "7461",
                    DateOpened = DateTime.Now,
                    DateClosed = DateTime.Now,
                    DailyLimit = 5000m,
                    ClientId = 2,
                    StatusId = 2
                },
                new
                {
                    AccountId = 3,
                    AccountType = "Corrente",
                    Agency = "7460",
                    AccountNumber = "7462",
                    DateOpened = DateTime.Now,
                    DateClosed = DateTime.Now,
                    DailyLimit = 2000m,
                    ClientId = 1,
                    StatusId = 1
                }
            );
        }
    }
}
