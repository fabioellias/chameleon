using System.Collections.Generic;
using Loja.Domain.Entities;

namespace Loja.Domain.Repositories
{
    public interface IPedidoRepository
    {
         List<Pedido> MeusPedidos(string email);
         Pedido Criar(Pedido pedido);
    }
}