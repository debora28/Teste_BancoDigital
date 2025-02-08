using Microsoft.EntityFrameworkCore;
using UserService.Model;
using System;

namespace UserService.Migrations
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        //Para cada entidade, criar um dbset:
        public DbSet<Usuario> Usuarios { get; set; }

        //Aqui se especifica qual a chave primária e outras definições de banco:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Criando as entidades:
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);

            //Alimentando as tabelas (seeding): 
            modelBuilder.Entity<Usuario>().HasData(
                new
                {
                    Id = 1,
                    Nome = "Admin",
                    Cpf = "08995228407",
                    DataNasc = new DateTime(1992, 01, 23)
                },
                new
                {
                    Id = 2,
                    Nome = "Fatima",
                    Cpf = "60671150006",
                    DataNasc = new DateTime(1963, 05, 04)
                },
                new
                {
                    Id = 3,
                    Nome = "Orlando",
                    Cpf = "47633984074",
                    DataNasc = new DateTime(1980, 12, 31)
                }
                );
        }
    }
}
