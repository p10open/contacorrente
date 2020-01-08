using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.DTO;

namespace Teste.ContaCorrente.Domain.Interfaces.Events
{
    public interface INotificacaoEvent
    {
        void Notificar(NotificacaoDTO notificacao);
        bool ExistemNotificacoes();
        void Notificar(object notificacao);
        List<NotificacaoDTO> ObterNotificacoes();
    }
}
