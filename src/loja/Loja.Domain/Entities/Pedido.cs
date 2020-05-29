using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using Loja.Shared.Entities;

namespace Loja.Domain.Entities
{
    public class Pedido : Entity
    {
        private IList<PedidoItem> itensDePedido;

        public Pedido(Cliente cliente)
        {
            Cliente = cliente;
            itensDePedido = new List<PedidoItem>();
        }

        public Cliente Cliente { get; private set; }
        public IReadOnlyCollection<PedidoItem> Itens { get { return itensDePedido.ToArray(); } }

        public void IncluirItem(Produto produto, int quantidade)
        {
            itensDePedido.Add(new PedidoItem(produto, quantidade));
        }
    }
}