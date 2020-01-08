using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.ContaCorrente.Domain.Interfaces.Events;
using Teste.ContaCorrente.Domain.DTO;
using Teste.ContaCorrente.Domain.Enums;

namespace Teste.ContaCorrente.API.Controllers.Base
{
    public class ControllerSuperType : ControllerBase
    {
        readonly INotificacaoEvent _notificacaoEvent;

        public ControllerSuperType(INotificacaoEvent notificacaoEvent)
        {
            _notificacaoEvent = notificacaoEvent;
        }

        protected bool ValidarViewModel(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var erros = modelState.Values.SelectMany(v => v.Errors);

                erros.ToList().ForEach
                (e =>
                    _notificacaoEvent.Notificar
                    (
                        NotificacaoDTO.NotificacaoFactory.ErroNegocio(e.ErrorMessage)
                    )
                );

                return false;
            }

            return true;
        }

        protected IActionResult ProcessarRetorno(object retorno = null)
        {
            if (_notificacaoEvent.ExistemNotificacoes())
            {
                var notificacao = _notificacaoEvent.ObterNotificacoes().FirstOrDefault();

                var mensagens = _notificacaoEvent.ObterNotificacoes().Select(x => x.Mensagem).ToList();

                if (notificacao.StatusProcessamento == EStatusProcessamento.ErroNegocio)
                    return BadRequest(mensagens);
                else if(notificacao.StatusProcessamento == EStatusProcessamento.ErroInterno)
                    return StatusCode(500, mensagens);
            }

            return Ok(retorno);
        }
    }
}
