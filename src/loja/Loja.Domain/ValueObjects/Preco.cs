using Flunt.Validations;
using Loja.Shared.ValueObjects;

namespace Loja.Domain.ValueObjects
{
    public class Preco : ValueObject
    {
        public Preco(decimal valor)
        {
            Valor = valor;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(0, Valor, "Preco.Valor", "Valor não pode ser negativo")
                .IsLowerThan(10000, Valor, "Preco.Valor", "Valor excede o valor máximo")
            );
        }

        public decimal Valor { get; private set; }

    }
}