using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.ContaCorrente.Domain.Entities;

namespace Teste.ContaCorrente.Infra.Data.Mappings
{
    public sealed class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE").HasKey(x=>x.Id);

            builder.Property(x => x.Id).HasColumnName("ID_CLIENTE").HasColumnType("int");
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("varchar(200)");
            builder.Property(x => x.CPF).HasColumnName("CPF").HasColumnType("numeric(11,0)");
            builder.Property(x => x.DataNascimento).HasColumnName("DT_NASC").HasColumnType("datetime2");
        }
    }
}
