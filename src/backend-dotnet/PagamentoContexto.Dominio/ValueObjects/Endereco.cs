using Flunt.Validations;
using PagamentoContexto.Compartilhado.ValueObjects;

namespace PagamentoContexto.Dominio.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string rua, string numero, string bairro, string cidade, string estado, string pais, string cEP)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            CEP = cEP;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Rua,3, "Endereco.Rua","A rua deve conter pelo menos 3 caracteres" )
            );
        }

        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; set; }
        public string CEP { get; private set; }
    }
}