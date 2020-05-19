using System;
using PagamentoContexto.Dominio.ValueObjects;

namespace PagamentoContexto.Dominio.Entidades
{
    public class CartaoCredito : Pagamento
    {
        public CartaoCredito(
            string nomeNoCartao,
            string numeroCartao,
            string numeroUltimaTransacao,
            DateTime dataPagamento,
            DateTime dataExpiracao,
            decimal total,
            decimal totalPago,
            string pagador,
            Documento documento,
            Endereco endereco,
                Email email) : base(dataPagamento, dataExpiracao, total, totalPago, pagador, documento, endereco, email)
        {
            this.NomeNoCartao = nomeNoCartao;
            this.NumeroCartao = numeroCartao;
            this.NumeroUltimaTransacao = numeroUltimaTransacao;
        }

        public string NomeNoCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string NumeroUltimaTransacao { get; private set; }
    }
}