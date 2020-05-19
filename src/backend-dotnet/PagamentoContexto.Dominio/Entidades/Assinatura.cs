using System.Linq;
using System;
using System.Collections.Generic;
using Flunt.Validations;
using PagamentoContexto.Compartilhado.Entidades;

namespace PagamentoContexto.Dominio.Entidades
{
    public class Assinatura : Entidade
    {
        private List<Pagamento> pagamentos;
        public Assinatura(DateTime? dataExpiracao)
        {
            DataCriacao = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            DataExpiracao = dataExpiracao;
            Ativo = true;
            pagamentos = new List<Pagamento>();
        }


        public DateTime DataCriacao { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        public DateTime? DataExpiracao { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyCollection<Pagamento> Pagamentos { get { return pagamentos.ToArray(); } }

        public void AdicionarPagamento(Pagamento pagamento)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, pagamento.DataPagamento, "Assinatura.Pagamentos", "A data do pagamento tem que ser futura")
            );

            pagamentos.Add(pagamento);
        }

        public void Ativar()
        {
            Ativo = true;
            DataUltimaAtualizacao = DateTime.Now;
        }

        public void Desativar()
        {
            Ativo = false;
            DataUltimaAtualizacao = DateTime.Now;
        }
    }
}