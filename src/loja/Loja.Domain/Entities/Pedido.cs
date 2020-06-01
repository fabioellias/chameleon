using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using Loja.Shared.Entities;

namespace Loja.Domain.Entities
{
    public class Pedido : Entity
    {
        private List<PedidoItem> itensDePedido;

        public Pedido(Cliente cliente)
        {
            Cliente = cliente;
            itensDePedido = new List<PedidoItem>();
        }

        public Cliente Cliente { get; private set; }
        public IReadOnlyCollection<PedidoItem> Itens { get { return itensDePedido.ToArray(); } }

        public void IncluirItem(Produto produto, int quantidade)
        {
            var item = new PedidoItem(produto, quantidade);

            if(item.Valid)
                itensDePedido.Add(item);

            AddNotifications(item);
        }

        public void RemoverItem(Produto produto){
            
            var index = itensDePedido.FindIndex(item => item.Produto.Codigo == produto.Codigo);

            itensDePedido.RemoveAt(index);
        }
    }
}