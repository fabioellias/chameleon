using System;
using System.Diagnostics;
using Bogus;
using Bogus.Extensions.Brazil;
using Loja.Domain.Entities;
using Loja.Domain.Enums;
using Loja.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Test.Unit.Entities
{
    [TestClass]
    public class PedidoTest
    {
        private Faker faker;

        private Endereco endereco;
        private Email email;
        private Nome nome;
        private Documento cpf;
        private Nascimento nascimento;
        private Preco preco;
        private ProdutoTipo produtoTipo;
        private Produto produto;

        [TestInitialize]
        public void Setup()
        {
            faker = new Faker("pt_BR");
            endereco = new Endereco(
                faker.Address.StreetName(),
                faker.Address.BuildingNumber(),
                faker.Address.City(),
                faker.Address.City(),
                faker.Address.StateAbbr(),
                faker.Address.ZipCode());

            email = new Email(faker.Person.Email);
            nome = new Nome(faker.Person.FirstName, faker.Person.LastName);
            cpf = new Documento(faker.Person.Cpf(), EDocumentoTipo.CPF);
            nascimento = new Nascimento(DateTime.Now.AddYears(-43));

            produtoTipo = new ProdutoTipo(faker.Commerce.Categories(1)[0]);
            preco = new Preco(faker.Random.Decimal(min: 1, max: 1000));
            produto = new Produto(
                faker.Random.Guid().ToString(),
                faker.Commerce.ProductName(),
                faker.Commerce.ProductAdjective(),
                preco,
                produtoTipo);

            Debug.WriteLine(endereco);

            Debug.WriteLine(produto);
        }

        [TestMethod]
        public void SucessoQuandoAdicionaProdutoOk()
        {
            var cliente = new Cliente(nome, cpf, endereco, email, nascimento);
            var pedido = new Pedido(cliente);

            pedido.IncluirItem(produto, 1);

            Assert.IsTrue(pedido.Valid);
        }

        [TestMethod]
        public void CriticaQuandoAdicionaProdutoSemEstoque()
        {
            var cliente = new Cliente(nome, cpf, endereco, email, nascimento);
            var pedido = new Pedido(cliente);

            produto.ZerarEstoque();

            pedido.IncluirItem(produto, 1);

            Assert.IsTrue(pedido.Invalid);
        }

        [TestMethod]
        public void CriticaQuandoAdicionaProdutoQueJaEstaNoPedido()
        {
            var cliente = new Cliente(nome, cpf, endereco, email, nascimento);
            var pedido = new Pedido(cliente);

            pedido.IncluirItem(produto, 1);
            pedido.IncluirItem(produto, 10);

            Assert.IsTrue(pedido.Invalid);
        }
    }
}