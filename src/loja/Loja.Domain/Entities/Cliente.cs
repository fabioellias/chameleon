using Loja.Domain.ValueObjects;
using Loja.Shared.Entities;

namespace Loja.Domain.Entities {
    public class Cliente : Entity {
        public Cliente (Nome nome, Documento cpf, Endereco endereco, Email email, Nascimento nascimento) {
            Nome = nome;
            CPF = cpf;
            Endereco = endereco;
            Email = email;
            Nascimento = nascimento;

             AddNotifications(nome, cpf, endereco, email, nascimento);
        }
        public Nome Nome { get; private set; }
        public Documento CPF { get; private set; }
        public Endereco Endereco { get; private set; }
        public Email Email { get; private set; }
        public Nascimento Nascimento { get; private set; }
    }
}