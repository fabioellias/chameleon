using Flunt.Validations;
using Loja.Domain.Enums;
using Loja.Shared.ValueObjects;

namespace Loja.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
         public Documento(string numero, EDocumentoTipo tipo)
        {
            Numero = numero;
            Tipo = tipo;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(this.Validate(), "Documento.Numero", "Documento inválido")
            );
        }

        public string Numero { get; private set; }
        public EDocumentoTipo Tipo { get; private set; }

        private bool Validate()
        {
            //todo: colocar a regra de validação para cpf e cnpj
            if (Tipo == EDocumentoTipo.CNPJ && Numero.Length == 14)
                return true;

            if (Tipo == EDocumentoTipo.CPF && Numero.Length == 11)
                return true;

            return false;
        }
    }
}