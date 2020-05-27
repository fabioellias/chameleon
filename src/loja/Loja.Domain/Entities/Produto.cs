using Loja.Domain.ValueObjects;
using Loja.Shared.Entities;

namespace Loja.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto(string codigo, string descricao, string detalhe, Preco valor, ProdutoTipo tipo)
        {
            Codigo = codigo;
            Descricao = descricao;
            Detalhe = detalhe;
            Valor = valor;
            EmEstoque = true;
            Tipo = tipo;
        }

        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string Detalhe { get; set; }
        public Preco Valor { get; private set; }
        public bool EmEstoque { get; private set; }
        public ProdutoTipo Tipo {get; private set;}

        public void ZerarEstoque(){
            EmEstoque = false;
        }
    }
}