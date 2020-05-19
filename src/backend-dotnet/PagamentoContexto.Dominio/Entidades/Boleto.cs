using System;
using PagamentoContexto.Dominio.ValueObjects;

namespace PagamentoContexto.Dominio.Entidades
{
    public class Boleto : Pagamento
    {
        public Boleto(
            string codigoBarras,
            string numeroBoleto,
            DateTime dataPagamento,
            DateTime dataExpiracao,
            decimal total,
            decimal totalPago,
            string pagador,
            Documento documento,
            Endereco endereco,
            Email email
            ) : base(dataPagamento, dataExpiracao, total, totalPago, pagador, documento, endereco, email)
        {
            CodigoBarras = codigoBarras;
            NumeroBoleto = numeroBoleto;
        }

        public string CodigoBarras { get; private set; }
        public string NumeroBoleto { get; private set; }
    }
}