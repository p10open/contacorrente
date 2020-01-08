using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.ContaCorrente.Domain.Entities
{
    public sealed class Cliente: Base.Entidade
    {
        public string Nome { get; set; }
        public decimal CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<Conta> Contas { get; set; }
    }
}
