using System.ComponentModel.DataAnnotations;

namespace Teste.ContaCorrente.API.ViewModels
{
    public class TransferenciaViewModel
    {
        [Required(ErrorMessage = "O campo Banco Origem é obrigatório")]
        public int BancoOrigem { get; set; }

        [Required(ErrorMessage = "O campo Conta Origem é obrigatório")]
        public int ContaOrigem { get; set; }

        [Required(ErrorMessage = "O campo Agencia Origem é obrigatório")]
        public int AgenciaOrigem { get; set; }

        [Required(ErrorMessage = "O campo Banco Destino é obrigatório")]
        public int BancoDestino { get; set; }

        [Required(ErrorMessage = "O campo Conta Destino é obrigatório")]
        public int ContaDestino { get; set; }

        [Required(ErrorMessage = "O campo Agencia Destino é obrigatório")]
        public int AgenciaDestino { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public decimal Valor { get; set; }
    }
}
