using Loja.Shared.Entities;

namespace Loja.Domain.Entities
{
    public class ProdutoTipo : Entity
    {
        public string Descricao { get; private set; }

        public ProdutoTipo(string descricao)
        {
            Descricao = descricao;
        }
    }
}