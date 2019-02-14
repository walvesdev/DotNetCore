using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CasaDoCodigo.AcessoDados.TypeConfiguration;
using Microsoft.Extensions.Logging;

namespace CasaDoCodigo.AcessoDados
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cadastro> Cadastro { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("User Id=postgres;Password=123456;Host=localhost;Port=5432;Database=CasadoCodigo");
                       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new ProdutoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CadastroTypeConfiguration());
        }
    }
}
