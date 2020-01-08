using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.ContaCorrente.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
