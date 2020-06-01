using Flunt.Validations;
using Loja.Shared.ValueObjects;

namespace Loja.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Logradouro, 3, "Endereco.Logradouro", "A rua deve conter pelo menos 3 caracteres")
                .HasMinLen(Bairro, 3, "Endereco.Bairro", "O bairro deve conter pelo menos 3 caracteres")
                .HasMinLen(Cidade, 3, "Endereco.Cidade", "A cidade deve conter pelo menos 3 caracteres")
                .HasMinLen(Estado, 2, "Endereco.Estado", "O estado deve conter pelo menos 2 caracteres")
                .HasLen(CEP, 8, "Endereco.CEP", "O cep deve conter 8 caracteres")
            );
        }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
    }
}