using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.DTO;
using Teste.ContaCorrente.Domain.Interfaces.Events;

namespace Teste.ContaCorrente.Domain.Services.Base
{
    public abstract class Service
    {
        readonly protected INotificacaoEvent _notificacaoEvent;

        public Service(INotificacaoEvent notificacaoEvent)
        {
            _notificacaoEvent = notificacaoEvent;
        }

        public void NotificarErroNegocio(string mensagem)
        {
            _notificacaoEvent.Notificar(NotificacaoDTO.NotificacaoFactory.ErroNegocio(mensagem));
        }

        public void NotificarErroNegocio(List<NotificacaoDTO> notificacoes)
        {
            notificacoes.ForEach(x => _notificacaoEvent.Notificar(x));
        }

        public void NotificarErroInterno(string mensagem)
        {
            _notificacaoEvent.Notificar(NotificacaoDTO.NotificacaoFactory.ErroInterno(mensagem));
        }
    }
}
