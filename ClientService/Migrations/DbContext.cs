using Microsoft.EntityFrameworkCore;
using ClientService.Model;
using System;

namespace ClientService.Migrations
{
    public class Bank01Context : DbContext
    {
        public Bank01Context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasKey(u => u.ClientId);

            modelBuilder.Entity<Client>().HasData(
                new
                {
                    ClientId = 1,
                    ClientName = "Admin",
                    CpfCnpj = "08995228407",
                    DateBirth = new DateTime(1992, 01, 23)
                },
                new
                {
                    ClientId = 2,
                    ClientName = "Maria",
                    CpfCnpj = "60671150006",
                    DateBirth = new DateTime(1963, 05, 04)
                },
                new
                {
                    ClientId = 3,
                    ClientName = "José",
                    CpfCnpj = "47633984074",
                    DateBirth = new DateTime(1980, 12, 31)
                }
            );
        }
    }
}
