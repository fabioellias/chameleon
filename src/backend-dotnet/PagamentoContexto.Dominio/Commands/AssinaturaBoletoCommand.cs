using System;
using Flunt.Notifications;
using Flunt.Validations;
using PagamentoContexto.Compartilhado.Commands;
using PagamentoContexto.Dominio.Enums;

namespace PagamentoContexto.Dominio.Commands
{
    public class AssinaturaBoletoCommand : Notifiable, ICommand
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string CodigoBarras { get; set; }
        public string NumeroBoleto { get; set; }
        public string NumeroPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string Pagador { get; set; }
        public string PagadorDocumento { get; set; }
        public EDocumentoTipo PagadorDocumentoTipo { get; set; }
        public string PagadorEmail { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(PrimeiroNome, 3, "Nome.PrimeiroNome", "Nome deve conter pelo menos 3 caracteres")
            .HasMinLen(UltimoNome, 3, "Nome.UltimoNome", "Sobrenome deve conter pelo menos 3 caracteres")
            .HasMaxLen(PrimeiroNome, 40, "Nome.PrimeiroNome", "Nome deve conter até 40 caracteres"));
        }
    }
}