using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.ContaCorrente.Domain.Entities.Base;
using Teste.ContaCorrente.Domain.Interfaces.Repositories.Base;
using Teste.ContaCorrente.Infra.Data.Context;

namespace Teste.ContaCorrente.Infra.Data.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : Entidade
    {
        readonly protected ContaContext _contaContext;
        DbSet<T> _entidade;

        public Repository(ContaContext contaContext)
        {
            _contaContext = contaContext;
            _entidade = _contaContext.Set<T>();
        }

        public void Adicionar(T entidade) => _entidade.Add(entidade);

        public void Atualizar(T entidade) => _entidade.Update(entidade);

        public T Buscar(int id) => _entidade.Find(id);
        
        public void Excluir(T entidade) => _entidade.Remove(entidade);

        public void Excluir(int id) => Excluir(Buscar(id));

        public IQueryable<T> Listar() => _entidade;
    }
}
