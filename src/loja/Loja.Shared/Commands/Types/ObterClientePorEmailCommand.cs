using System;
using Loja.Shared.Commands;

namespace Loja.Shared.Commands.Types
{
    public class ObterClientePorEmailCommand : ICommand
    {
        public string Email { get; set; }
        public void Validate()
        {
            //
        }
    }
}