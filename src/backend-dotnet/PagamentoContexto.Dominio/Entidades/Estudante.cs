using System.Linq;
using System.Collections.Generic;
using PagamentoContexto.Dominio.ValueObjects;
using PagamentoContexto.Compartilhado.Entidades;
using Flunt.Validations;

namespace PagamentoContexto.Dominio.Entidades
{
    public class Estudante : Entidade
    {
        private IList<Assinatura> assinaturas;
        public Estudante(Nome nome, Documento documento, Email email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;

            assinaturas = new List<Assinatura>();

            AddNotifications(nome, documento, email);
        }
        public Nome Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return assinaturas.ToArray(); } }

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            var temAssinaturaAtiva = assinaturas.Any(item => item.Ativo);

            AddNotifications(new Contract()
            .Requires()
            .IsFalse(temAssinaturaAtiva, "Estudante.Assinaturas", "Você já tem uma assinatura ativa")
            .IsLowerThan(0, assinatura.Pagamentos.Count, "Estudante.Assinaturas", "Esta assinatura não possui pagamentos."));

            if (temAssinaturaAtiva)
                AddNotification("Estudante.Assinaturas", "Você já tem uma assinatura ativa");

            assinaturas.Add(assinatura);
        }
    }
}