using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.AcessoDados.TypeConfiguration
{
    public class ItemPedidoTypeConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            //chave primaria compsta
            builder.HasKey(p => new { p.PedidoId, p.ProdutoId });
            builder.HasOne(p => p.Pedido);
            builder.HasOne(p => p.Produto);
            builder.ToTable("ItemPedido");
        }
    }
}
