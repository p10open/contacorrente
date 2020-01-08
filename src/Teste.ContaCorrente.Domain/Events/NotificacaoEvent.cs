using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.DTO;
using Teste.ContaCorrente.Domain.Interfaces.Events;
using System.Linq;

namespace Teste.ContaCorrente.Domain.Events
{
    public sealed class NotificacaoEvent: INotificacaoEvent
    {
        public List<NotificacaoDTO> Notificacoes { get; set; }

        public NotificacaoEvent()
        {
            Notificacoes = new List<NotificacaoDTO>();
        }

        public void Notificar(NotificacaoDTO notificacao)
        {
            Notificacoes.Add(notificacao);
        }

        public bool ExistemNotificacoes()
        {
            return Notificacoes.Any();
        }

        public void Notificar(object notificacao)
        {
            throw new NotImplementedException();
        }

        public List<NotificacaoDTO> ObterNotificacoes()
        {
            return Notificacoes;
        }
    }
}
