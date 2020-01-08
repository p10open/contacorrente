using Teste.ContaCorrente.Domain.Entities;
using Teste.ContaCorrente.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.ContaCorrente.Domain.Interfaces.Repositories
{
    public interface IContaRepository: IRepository<Conta>
    {
        Conta Buscar(int banco, int codigo, int agencia);
        void AdicionarLancamento(Lancamento lancamento);
    }
}
