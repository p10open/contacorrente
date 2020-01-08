using System;
using Teste.ContaCorrente.Domain.Services;
using Xunit;
using Moq;
using Teste.ContaCorrente.Domain.Interfaces.UoW;
using Teste.ContaCorrente.Domain.Interfaces.Repositories;
using Teste.ContaCorrente.Domain.Events;
using Teste.ContaCorrente.Domain.DTO;
using Teste.ContaCorrente.Domain.Entities;

namespace Teste.ContaCorrente.Test.Unitario
{
    public class ContaCorrenteUnitTest
    {
        ContaService _contaService;
        Mock<IUnitOfWork> _unitOfWork;
        Mock<IContaRepository> _contaRepository;
        NotificacaoEvent _notificacaoEvent;
        Conta _conta1;
        Conta _conta2;

        public ContaCorrenteUnitTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _contaRepository = new Mock<IContaRepository>();
            _notificacaoEvent = new NotificacaoEvent();

            _conta1 = new Conta
            {
                Agencia = 1542,
                Codigo = 113856,
                IdBanco = 33,
                Ativa = true,
                IdCliente = 1,
                DataAbertura = DateTime.Now,
                Limite = 10000,
                TipoConta = Domain.Enums.ETIpoConta.Corrente
            };

            _contaRepository.Setup(x=>x.Buscar(33, 113856, 1542))
                .Returns(_conta1);

            _conta2 = new Conta
            {
                Agencia = 1643,
                Codigo = 114856,
                IdBanco = 33,
                Ativa = true,
                IdCliente = 2,
                DataAbertura = DateTime.Now,
                Limite = 1000,
                TipoConta = Domain.Enums.ETIpoConta.Corrente
            };

            _contaRepository.Setup(x => x.Buscar(33, 114856, 1643))
                .Returns(_conta2);

            _contaService = new ContaService
            (
                _contaRepository.Object,
                _unitOfWork.Object,
                _notificacaoEvent
            );
        }

        [Fact]
        public void Deve_Retornar_Mensagem_Valor_Nao_Informado()
        {
            var transferencia = new TransferenciaDTO
            {
                AgenciaDestino = 1542,
                AgenciaOrigem = 1643,
                BancoDestino = 33,
                BancoOrigem = 33,
                ContaDestino = 113856,
                ContaOrigem = 114856
            };

            _contaService.Transferir(transferencia);

            Assert.True(_notificacaoEvent.ExistemNotificacoes());
        }

        [Fact]
        public void Deve_Retornar_Mensagem_Saldo_Insuficiente()
        {
            var transferencia = new TransferenciaDTO
            {
                AgenciaDestino = 1542,
                AgenciaOrigem = 1643,
                BancoDestino = 33,
                BancoOrigem = 33,
                ContaDestino = 113856,
                ContaOrigem = 114856,
                Valor = 2000
            };

            _contaService.Transferir(transferencia);

            Assert.True(_notificacaoEvent.ExistemNotificacoes());
        }

        [Fact]
        public void Deve_Creditar_Valor_Conta()
        {
            var transferencia = new TransferenciaDTO
            {
                AgenciaDestino = 1542,
                AgenciaOrigem = 1643,
                BancoDestino = 33,
                BancoOrigem = 33,
                ContaDestino = 113856,
                ContaOrigem = 114856,
                Valor = 1000
            };

            var valorInicial = _conta1.Saldo;
            
            _contaService.Transferir(transferencia);

            Assert.True(_conta1.Saldo > valorInicial);
        }

        [Fact]
        public void Deve_Debitar_Valor_Conta()
        {
            var transferencia = new TransferenciaDTO
            {
                AgenciaDestino = 1542,
                AgenciaOrigem = 1643,
                BancoDestino = 33,
                BancoOrigem = 33,
                ContaDestino = 113856,
                ContaOrigem = 114856,
                Valor = 1000
            };

            var valorInicial = _conta2.Saldo;

            _contaService.Transferir(transferencia);

            Assert.True(_conta2.Saldo < valorInicial);
        }
    }
}
