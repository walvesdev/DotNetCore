using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.AcessoDados.TypeConfiguration
{
    public class CadastroTypeConfiguration : IEntityTypeConfiguration<Cadastro>
    {
        public void Configure(EntityTypeBuilder<Cadastro> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Pedido);
            builder.ToTable("Cadastro");
        }
    }
}
