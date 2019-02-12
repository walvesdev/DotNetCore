using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CasaDoCodigo.AcessoDados
{
    public class ApplicationContext : DbContext
    {
        //Opcional se declarada as criações da tabelas no modelbuilder
        public DbSet<Cadastro> Cadastro { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add propriedade ToTable se der erro de FK
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().ToTable("Produto");

            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Itens).WithOne(p => p.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cadastro).WithOne(p => p.Pedido).IsRequired();
            //modelBuilder.Entity<Pedido>().OwnsOne(p => p.Cadastro);
            modelBuilder.Entity<Pedido>().ToTable("Pedido");


            modelBuilder.Entity<ItemPedido>().HasKey(p => p.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(p => p.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(p => p.Produto);
            modelBuilder.Entity<ItemPedido>().ToTable("ItemPedido");

            modelBuilder.Entity<Cadastro>().HasKey(p => p.Id);
            modelBuilder.Entity<Cadastro>().HasOne(p => p.Pedido);
            modelBuilder.Entity<Cadastro>().ToTable("Cadastro");



        }
    }
}
