using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.Entities;

namespace Teste.ContaCorrente.Infra.Data.Mappings
{
    public sealed class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("CONTA").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID_CONTA").HasColumnType("int");
            builder.Property(x => x.Codigo).HasColumnName("COD_CONTA").HasColumnType("int");
            builder.Property(x => x.IdBanco).HasColumnName("ID_BANCO").HasColumnType("int");
            builder.Property(x => x.IdCliente).HasColumnName("ID_CLIENTE").HasColumnType("int");
            builder.Property(x => x.Limite).HasColumnName("LIMITE").HasColumnType("numeric(10,2)");
            builder.Property(x => x.Saldo).HasColumnName("SALDO").HasColumnType("numeric(10,2)");
            builder.Property(x => x.TipoConta).HasColumnName("TP_CONTA").HasColumnType("int");
            builder.Property(x => x.Agencia).HasColumnName("AGENCIA").HasColumnType("int");
            builder.Property(x => x.Ativa).HasColumnName("ATIVA").HasColumnType("bit");
            builder.Property(x => x.DataAbertura).HasColumnName("DT_ABERTURA").HasColumnType("datetime2");
            builder.Property(x => x.DataFechamento).HasColumnName("DT_FECHAMENTO").HasColumnType("datetime2");

            builder.HasOne(x => x.Banco).WithMany(x => x.Contas).HasForeignKey(x => x.IdBanco);
            builder.HasOne(x => x.Cliente).WithMany(x => x.Contas).HasForeignKey(x => x.IdCliente);
        }
    }
}
