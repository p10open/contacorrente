using System;
using System.Collections;
using System.Collections.Generic;
using Teste.ContaCorrente.Domain.Enums;

namespace Teste.ContaCorrente.Domain.Entities
{
    public sealed class Conta: Base.Entidade
    {
        public int Codigo { get; set; }
        public int Agencia { get; set; }
        public decimal Saldo { get; private set; }
        public decimal Limite { get; set; }
        public ETIpoConta TipoConta { get; set; }
        public int IdCliente { get; set; }
        public int IdBanco { get; set; }
        public DateTime DataAbertura { get; set; }
        public bool Ativa { get; set; }
        public DateTime? DataFechamento { get; set; }
        public Banco Banco { get; set; }
        public Cliente Cliente { get; set; }

        public void Creditar(decimal valor)
        {
            Saldo += valor;
        }

        public bool Debitar(decimal valor)
        {
            if (valor > (Saldo + Limite))
                return false;

            Saldo -= valor;

            return true;
        }
    }
}
