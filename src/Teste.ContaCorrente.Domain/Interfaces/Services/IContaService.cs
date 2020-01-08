using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.DTO;

namespace Teste.ContaCorrente.Domain.Interfaces.Services
{
    public interface IContaService
    {
        void Transferir(TransferenciaDTO transferenciaDTO);
    }
}
