using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.Entities;
using Teste.ContaCorrente.Domain.Interfaces.Repositories;
using Teste.ContaCorrente.Infra.Data.Context;
using System.Linq;

namespace Teste.ContaCorrente.Infra.Data.Repositories
{
    public sealed class ContaRepository : Base.Repository<Conta>, IContaRepository
    {
        public ContaRepository(ContaContext contaContext) : base(contaContext)
        {
        }

        public Conta Buscar(int banco, int codigo, int agencia) =>
          _contaContext.Conta.SingleOrDefault
            (x =>
                 x.Banco.Codigo == banco
                 && x.Codigo == codigo
                 && x.Agencia == agencia
            );

        public void AdicionarLancamento(Lancamento lancamento) =>
            _contaContext.Lancamento.Add(lancamento);
    }
}
