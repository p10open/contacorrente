using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.ContaCorrente.Domain.DTO;
using Teste.ContaCorrente.Domain.Enums;
using Teste.ContaCorrente.Domain.Interfaces.Services;
using AutoMapper;
using Teste.ContaCorrente.API.ViewModels;
using Teste.ContaCorrente.Domain.Interfaces.Events;

namespace Teste.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : Base.ControllerSuperType
    {
        readonly IContaService _contaService;
        readonly IMapper _mapper;

        public ContaController
        (
            IContaService contaService,
            IMapper mapper,
            INotificacaoEvent notificacaoEvent
        )
            : base(notificacaoEvent)
        {
            _contaService = contaService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TransferenciaViewModel transferenciaViewModel)
        {
            if (ValidarViewModel(ModelState))
            {
                var transferencia = _mapper.Map<TransferenciaDTO>(transferenciaViewModel);

                _contaService.Transferir(transferencia);
            }

            return ProcessarRetorno("Transferência realizada com sucesso");
        }
    }
}
