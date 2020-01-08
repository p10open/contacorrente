using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Teste.ContaCorrente.Domain.DTO;

namespace Teste.ContaCorrente.Domain.Validacoes
{
    public sealed class TransferenciaValidator: AbstractValidator<TransferenciaDTO>
    {
        public TransferenciaValidator()
        {
            RuleFor(x => x.AgenciaDestino).NotEmpty().WithMessage("Informe a Agência de Destino");
            RuleFor(x => x.AgenciaOrigem).NotEmpty().WithMessage("Informe a Agência de Origem");
            RuleFor(x => x.BancoDestino).NotEmpty().WithMessage("Informe o Banco de Destino");
            RuleFor(x => x.BancoOrigem).NotEmpty().WithMessage("Informe o Banco de Origem");
            RuleFor(x => x.ContaDestino).NotEmpty().WithMessage("Informe a Conta de Destino");
            RuleFor(x => x.ContaOrigem).NotEmpty().WithMessage("Informe a Conta de Origem");
            RuleFor(x => x.Valor).NotEmpty().WithMessage("Informe o valor a ser transferido");
        }
    }
}
