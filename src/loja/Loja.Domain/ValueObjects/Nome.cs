using Flunt.Validations;
using Loja.Shared.ValueObjects;

namespace Loja.Domain.ValueObjects
{
   public class Nome : ValueObject
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(PrimeiroNome, 3, "Nome.PrimeiroNome", "Nome deve conter pelo menos 3 caracteres")
            .HasMinLen(UltimoNome, 3, "Nome.UltimoNome", "Sobrenome deve conter pelo menos 3 caracteres")
            .HasMaxLen(PrimeiroNome, 40, "Nome.PrimeiroNome", "Nome deve conter até 40 caracteres"));
        }

        public override string ToString(){
            return $"{PrimeiroNome} {UltimoNome}";
        }
    }
}