using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.Interfaces.UoW;
using Teste.ContaCorrente.Infra.Data.Context;

namespace Teste.ContaCorrente.Infra.Data.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        readonly ContaContext _contaContext;

        public UnitOfWork(ContaContext contaContext)
        {
            _contaContext = contaContext;
        }

        public void Commit()
        {
            _contaContext.SaveChanges();
        }
    }
}
