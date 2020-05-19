using System;
using Flunt.Notifications;
using PagamentoContexto.Compartilhado.Commands;
using PagamentoContexto.Dominio.Enums;

namespace PagamentoContexto.Dominio.Commands
{
    public class AssinaturaPayPalCommand : Notifiable, ICommand
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string CodigoTransacao { get; set; }
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
            throw new NotImplementedException();
        }
    }
}