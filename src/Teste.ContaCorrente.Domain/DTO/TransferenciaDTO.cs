using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.ContaCorrente.Domain.Validacoes;

namespace Teste.ContaCorrente.Domain.DTO
{
    public sealed class TransferenciaDTO
    {
        public int BancoOrigem { get; set; }
        public int ContaOrigem { get; set; }
        public int AgenciaOrigem { get; set; }
        public int BancoDestino { get; set; }
        public int ContaDestino { get; set; }
        public int AgenciaDestino { get; set; }
        public decimal Valor { get; set; }

        public List<NotificacaoDTO> Validar()
        {
            var validator = new TransferenciaValidator();

            var validacao = validator.Validate(this);

            if (!validacao.IsValid)
                return validacao.Errors.Select(x => NotificacaoDTO.NotificacaoFactory.ErroNegocio(x.ErrorMessage)).ToList();

            return new List<NotificacaoDTO>();
        }
    }
}
