using System.Data;
using System.Security.AccessControl;
using System;
using Loja.Shared.Commands;

namespace Loja.Shared.Commands.Types
{
    public class CadastrarClienteCommand : ICommand
    {
        public string Email { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome  { get; set; }
        public string CPF { get; set; }
         public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public DateTime Nascimento { get; set; }
        public void Validate()
        {
            //
        }
    }
}