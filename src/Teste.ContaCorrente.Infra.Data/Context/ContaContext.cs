using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Entity;
using System.Text;
using Teste.ContaCorrente.Domain.Entities;
using Teste.ContaCorrente.Infra.Data.Mappings;

namespace Teste.ContaCorrente.Infra.Data.Context
{
    public sealed class ContaContext : DbContext
    {
        public ContaContext(DbContextOptions<ContaContext> options) : base(options) { }


        public DbSet<Banco> Banco { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Lancamento> Lancamento { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BancoMap());
            modelBuilder.ApplyConfiguration(new ContaMap());
            modelBuilder.ApplyConfiguration(new LancamentoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
