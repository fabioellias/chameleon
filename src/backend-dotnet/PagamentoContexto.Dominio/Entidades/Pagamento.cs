using System;
using Flunt.Validations;
using PagamentoContexto.Compartilhado.Entidades;
using PagamentoContexto.Dominio.ValueObjects;

namespace PagamentoContexto.Dominio.Entidades
{
    public abstract class Pagamento : Entidade
    {
        protected Pagamento(DateTime dataPagamento, DateTime dataExpiracao, decimal total, decimal totalPago, string pagador, Documento documento, Endereco endereco, Email email)
        {
            Numero = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            DataPagamento = dataPagamento;
            DataExpiracao = dataExpiracao;
            Total = total;
            TotalPago = totalPago;
            Pagador = pagador;
            Documento = documento;
            Endereco = endereco;
            Email = email;

            AddNotifications(new Contract()
            .Requires()
            .IsLowerOrEqualsThan(0, Total, "Pagamento.Total", "O total não pode ser zero")
            .IsGreaterOrEqualsThan(Total, TotalPago, "Pagamento.TotalPago", "o total não pode ser menor que o total pago"));
        }

        public string Numero { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataExpiracao { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public string Pagador { get; private set; }
        public Documento Documento { get; private set; }
        public Endereco Endereco { get; private set; }
        public Email Email { get; private set; }
    }
}