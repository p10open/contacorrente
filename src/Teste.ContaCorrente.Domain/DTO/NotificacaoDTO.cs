using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.Enums;

namespace Teste.ContaCorrente.Domain.DTO
{
    public class NotificacaoDTO
    {
        public string Mensagem { get; set; }
        public EStatusProcessamento StatusProcessamento { get; set; }

        public static class NotificacaoFactory
        { 
            public static NotificacaoDTO ErroInterno(string mensagem)
            {
                return new NotificacaoDTO
                {
                    Mensagem = mensagem,
                    StatusProcessamento = EStatusProcessamento.ErroInterno
                };
            }

            public static NotificacaoDTO ErroNegocio(string mensagem)
            {
                return new NotificacaoDTO
                {
                    Mensagem = mensagem,
                    StatusProcessamento = EStatusProcessamento.ErroNegocio
                };
            }
        }
    }
}
