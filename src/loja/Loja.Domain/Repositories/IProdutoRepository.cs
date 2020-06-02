using System.Collections.Generic;
using Loja.Domain.Entities;

namespace Loja.Domain.Repositories
{
    public interface IProdutoRepository
    {
         List<Produto> ListarProdutoParaVenda();
    }
}