using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.AcessoDados.TypeConfiguration
{
    public class PedidoTypeConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.ItemPedido).WithOne(p => p.Pedido);
            builder.HasOne(p => p.Cadastro).WithOne(p => p.Pedido).IsRequired();
            builder.ToTable("Pedido");
        }
    }
}
