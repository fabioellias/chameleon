using System.Data;
using System.Security.AccessControl;
using System;
using Loja.Shared.Commands;
using System.Collections.Generic;

namespace Loja.Shared.Commands.Types
{
    public class MeusPedidosCommand : ICommand
    {
        public MeusPedidosCommand()
        {
            
        }
        public string EmailCliente { get; set; }

        public void Validate()
        {
            //
        }
    }
}