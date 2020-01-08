using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.ContaCorrente.Domain.DTO;
using Teste.ContaCorrente.Domain.Entities;
using Teste.ContaCorrente.Domain.Interfaces.Events;
using Teste.ContaCorrente.Domain.Interfaces.Repositories;
using Teste.ContaCorrente.Domain.Interfaces.Services;
using Teste.ContaCorrente.Domain.Interfaces.UoW;

namespace Teste.ContaCorrente.Domain.Services
{
    public sealed class ContaService : Base.Service, IContaService
    {
        readonly IContaRepository _contaRepository;
        readonly IUnitOfWork _unitOfWork;

        public ContaService
        (
            IContaRepository contaRepository,
            IUnitOfWork unitOfWork,
            INotificacaoEvent notificacaoEvent
        )
            : base(notificacaoEvent)
        {
            _contaRepository = contaRepository;
            _unitOfWork = unitOfWork;
        }

        public void Transferir(TransferenciaDTO transferenciaDTO)
        {
            var notificacoes = transferenciaDTO.Validar();

            if(notificacoes.Any())
            {
                NotificarErroNegocio(notificacoes);
                return;
            }

            var contaOrigem = _contaRepository.Buscar
            (
                transferenciaDTO.BancoOrigem,
                transferenciaDTO.ContaOrigem,
                transferenciaDTO.AgenciaOrigem
            );

            if (contaOrigem == null)
            {
                NotificarErroNegocio("Conta de origem não encontrada");
                return;
            }

            var contaDestino = _contaRepository.Buscar
            (
                transferenciaDTO.BancoDestino, 
                transferenciaDTO.ContaDestino, 
                transferenciaDTO.AgenciaDestino
            );

            if (contaDestino == null)
            {
                NotificarErroNegocio("Conta de Destino não encontrada");
                return;
            }

            if (!contaOrigem.Debitar(transferenciaDTO.Valor))
            {
                NotificarErroNegocio("Saldo insuficiente para completar a operação");
                return;
            }

            contaDestino.Creditar(transferenciaDTO.Valor);

            var lancamento = new Lancamento
            {
                ContaDestino = contaDestino,
                ContaOrigem = contaOrigem,
                Data = DateTime.Now,
                Valor = transferenciaDTO.Valor
            };

            _contaRepository.Atualizar(contaOrigem);
            _contaRepository.Atualizar(contaDestino);
            _contaRepository.AdicionarLancamento(lancamento);

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                NotificarErroInterno(ex.Message);
            }
        }
    }
}
