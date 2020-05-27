using Flunt.Validations;
using Loja.Shared.Entities;

namespace Loja.Domain.Entities
{
    public class PedidoItem : Entity
    {
        public PedidoItem(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;

            AddNotifications(new Contract()
           .Requires()
           .IsTrue(Produto.EmEstoque, "Produto.EmEstoque", "Produto não possui estoque")
           .IsGreaterThan(quantidade, 0, "Produto.Quantidade", "Quantidade inválida."));
        }

        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }

    }
}