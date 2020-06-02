using System;
using Loja.Domain.Entities;
using Loja.Domain.Enums;
using Loja.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Test.Unit.Entities
{
    [TestClass]
    public class PedidoTest
    {

        [TestMethod]
        public void SucessoQuandoAdicionaProdutoOk()
        {

            var nome = new Nome("Fabio", "Elias");
            var cpf = new Documento("042.664.770-07", EDocumentoTipo.CPF);
            var endereco = new Endereco("Rua dos diamantes", "9000", "Cabo Frio", "Cabo Frio", "RJ", "22505900");
            var email = new Email("fabio@fabio.com.br");
            var nascimento = new Nascimento(DateTime.Now.AddYears(-43));
            var cliente = new Cliente(nome, cpf, endereco, email, nascimento);
            var pedido = new Pedido(cliente);

            var produtoTipo = new ProdutoTipo("Periféricos");
            var preco = new Preco(50);
            var produto = new Produto("ABC123", "Mouse", "Sem fio", preco, produtoTipo);

            pedido.IncluirItem(produto, 1);

            Assert.IsTrue(pedido.Valid);
        }

        [TestMethod]
        public void CriticaQuandoAdicionaProdutoSemEstoque()
        {

            var nome = new Nome("Fabio", "Elias");
            var cpf = new Documento("042.664.770-07", EDocumentoTipo.CPF);
            var endereco = new Endereco("Rua dos diamantes", "9000", "Cabo Frio", "Cabo Frio", "RJ", "22505900");
            var email = new Email("fabio@fabio.com.br");
            var nascimento = new Nascimento(DateTime.Now.AddYears(-43));
            var cliente = new Cliente(nome, cpf, endereco, email, nascimento);
            var pedido = new Pedido(cliente);

            var produtoTipo = new ProdutoTipo("Periféricos");
            var preco = new Preco(50);
            var produto = new Produto("ABC123", "Mouse", "Sem fio", preco, produtoTipo);

            produto.ZerarEstoque();

            pedido.IncluirItem(produto, 1);

            Assert.IsTrue(pedido.Invalid);
        }

        [TestMethod]
        public void CriticaQuandoAdicionaProdutoQueJaEstaNoPedido()
        {

            var nome = new Nome("Fabio", "Elias");
            var cpf = new Documento("042.664.770-07", EDocumentoTipo.CPF);
            var endereco = new Endereco("Rua dos diamantes", "9000", "Cabo Frio", "Cabo Frio", "RJ", "22505900");
            var email = new Email("fabio@fabio.com.br");
            var nascimento = new Nascimento(DateTime.Now.AddYears(-43));
            var cliente = new Cliente(nome, cpf, endereco, email, nascimento);
            var pedido = new Pedido(cliente);

            var produtoTipo = new ProdutoTipo("Periféricos");
            var preco = new Preco(50);
            var produto = new Produto("ABC123", "Mouse", "Sem fio", preco, produtoTipo);

            pedido.IncluirItem(produto, 1);
            pedido.IncluirItem(produto, 10);

            Assert.IsTrue(pedido.Invalid);
        }

    }
}