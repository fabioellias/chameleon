using System.Data;
using System.Security.AccessControl;
using System;
using Loja.Shared.Commands;
using System.Collections.Generic;

namespace Loja.Shared.Commands.Types
{
    public class CriarPedidoCommand : ICommand
    {
        public CriarPedidoCommand()
        {
            Itens = new List<ItemPedido>();
        }
        public string EmailCliente { get; set; }

        public List<ItemPedido> Itens { get; set; }

        public class ItemPedido
        {
            public int Quantidade { get; set; }
            public string CodigoProduto { get; set; }
        }

        public void Validate()
        {
            //
        }
    }
}