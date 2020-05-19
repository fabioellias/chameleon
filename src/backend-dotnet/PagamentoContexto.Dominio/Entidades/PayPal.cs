using System;
using PagamentoContexto.Dominio.ValueObjects;

namespace PagamentoContexto.Dominio.Entidades
{
    public class PayPal : Pagamento
    {
        public string CodigoTransacao { get; private set; }

        public PayPal(
            string codigoTransacao,
            DateTime dataPagamento,
            DateTime dataExpiracao,
            decimal total,
            decimal totalPago,
            string pagador,
            Documento documento,
            Endereco endereco,
             Email email) : base(dataPagamento, dataExpiracao, total, totalPago, pagador, documento, endereco, email)
        {
            CodigoTransacao = codigoTransacao;
        }
    }
}