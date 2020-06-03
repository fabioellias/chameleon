using System;
using Flunt.Validations;
using Loja.Shared.ValueObjects;

namespace Loja.Domain.ValueObjects
{
    public class Nascimento : ValueObject
    {
        public Nascimento(DateTime data)
        {
            Data = data;

              AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(Data, DateTime.Now.AddYears(-18), "Nascimento.Data", "Proibido para menores de 18 anos"));
        }

        public DateTime Data { get; private set; }        
    }
}