using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.Entities;

namespace Teste.ContaCorrente.Infra.Data.Mappings
{
    public sealed class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("LANCAMENTO").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID_LANCAMENTO").HasColumnType("int");
            builder.Property(x => x.Valor).HasColumnName("VALOR").HasColumnType("numeric(10,2)");
            builder.Property(x => x.Data).HasColumnName("DT_LANCAMENTO").HasColumnType("datetime2");
            builder.Property(x => x.IdContaDestino).HasColumnName("ID_CONTA_DESTINO").HasColumnType("int");
            builder.Property(x => x.IdContaOrigem).HasColumnName("ID_CONTA_ORIGEM").HasColumnType("int");

            builder.HasOne(x => x.ContaOrigem).WithMany().HasForeignKey(x => x.IdContaOrigem);
            builder.HasOne(x => x.ContaDestino).WithMany().HasForeignKey(x => x.IdContaDestino);
        }
    }
}
