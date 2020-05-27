using Flunt.Validations;
using Loja.Shared.ValueObjects;

namespace Loja.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string EnderecoEmail { get; private set; }

        public Email(string endereco)
        {
            EnderecoEmail = endereco;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(EnderecoEmail, "Email.Endereco", "E-mail inválido")
            );
        }
    }
}