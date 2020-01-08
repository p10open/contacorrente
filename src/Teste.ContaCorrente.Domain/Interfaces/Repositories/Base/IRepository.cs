using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.ContaCorrente.Domain.Entities.Base;

namespace Teste.ContaCorrente.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T: Entidade
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        void Excluir(int id);
        T Buscar(int id);
        IQueryable<T> Listar();
    }
}
