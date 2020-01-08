using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.ContaCorrente.Domain.Entities
{
    public sealed class Lancamento: Base.Entidade
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int IdContaOrigem { get; set; }
        public int IdContaDestino { get; set; }
        public Conta ContaOrigem { get; set; }
        public Conta ContaDestino { get; set; }
    }
}
