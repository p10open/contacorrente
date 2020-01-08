﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teste.ContaCorrente.Infra.Data.Context;

namespace Teste.ContaCorrente.Infra.Data.Migrations
{
    [DbContext(typeof(ContaContext))]
    [Migration("20200108030119_correcao")]
    partial class correcao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teste.ContaCorrente.Domain.Entities.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_BANCO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnName("COD_BANCO")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnName("NOME")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("BANCO");
                });

            modelBuilder.Entity("Teste.ContaCorrente.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_CLIENTE")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CPF")
                        .HasColumnName("CPF")
                        .HasColumnType("numeric(11,0)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DT_NASC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnName("NOME")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CLIENTE");
                });

            modelBuilder.Entity("Teste.ContaCorrente.Domain.Entities.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_CONTA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Agencia")
                        .HasColumnName("AGENCIA")
                        .HasColumnType("int");

                    b.Property<bool>("Ativa")
                        .HasColumnName("ATIVA")
                        .HasColumnType("bit");

                    b.Property<int>("Codigo")
                        .HasColumnName("COD_CONTA")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnName("DT_ABERTURA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnName("DT_FECHAMENTO")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdBanco")
                        .HasColumnName("ID_BANCO")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnName("ID_CLIENTE")
                        .HasColumnType("int");

                    b.Property<decimal>("Limite")
                        .HasColumnName("LIMITE")
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("Saldo")
                        .HasColumnName("SALDO")
                        .HasColumnType("numeric(10,2)");

                    b.Property<int>("TipoConta")
                        .HasColumnName("TP_CONTA")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBanco");

                    b.HasIndex("IdCliente");

                    b.ToTable("CONTA");
                });

            modelBuilder.Entity("Teste.ContaCorrente.Domain.Entities.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_LANCAMENTO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnName("DT_LANCAMENTO")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdContaDestino")
                        .HasColumnName("ID_CONTA_DESTINO")
                        .HasColumnType("int");

                    b.Property<int>("IdContaOrigem")
                        .HasColumnName("ID_CONTA_ORIGEM")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnName("VALOR")
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdContaDestino");

                    b.HasIndex("IdContaOrigem");

                    b.ToTable("LANCAMENTO");
                });

            modelBuilder.Entity("Teste.ContaCorrente.Domain.Entities.Conta", b =>
                {
                    b.HasOne("Teste.ContaCorrente.Domain.Entities.Banco", "Banco")
                        .WithMany("Contas")
                        .HasForeignKey("IdBanco")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Teste.ContaCorrente.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Contas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Teste.ContaCorrente.Domain.Entities.Lancamento", b =>
                {
                    b.HasOne("Teste.ContaCorrente.Domain.Entities.Conta", "ContaDestino")
                        .WithMany()
                        .HasForeignKey("IdContaDestino")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Teste.ContaCorrente.Domain.Entities.Conta", "ContaOrigem")
                        .WithMany()
                        .HasForeignKey("IdContaOrigem")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}