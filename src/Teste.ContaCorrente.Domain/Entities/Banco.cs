using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.ContaCorrente.Domain.Entities
{
    public sealed class Banco: Base.Entidade
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public ICollection<Conta> Contas { get; set; }
    }
}
