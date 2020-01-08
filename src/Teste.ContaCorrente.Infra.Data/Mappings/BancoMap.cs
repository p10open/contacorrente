using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.ContaCorrente.Domain.Entities;

namespace Teste.ContaCorrente.Infra.Data.Mappings
{
    public sealed class BancoMap : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.ToTable("BANCO").HasKey(x=>x.Id);

            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("varchar(200)");
            builder.Property(x => x.Id).HasColumnName("ID_BANCO").HasColumnType("int");
            builder.Property(x => x.Codigo).HasColumnName("COD_BANCO").HasColumnType("int");
        }
    }
}
