using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Loja.Domain.Entities;
using Loja.Domain.Handlers;
using Loja.Domain.Repositories;
using Loja.Shared.Commands.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Loja.Domain.ValueObjects;
using Bogus.Extensions.Brazil;
using Loja.Domain.Enums;

namespace Loja.Test.Unit.Handlers
{
    [TestClass]
    public class ClienteHandlerTest
    {
        private Mock<IClienteRepository> clienteRepository;
        private List<Cliente> clientes;
        private Faker faker;

        [TestInitialize]
        public void Setup()
        {
            faker = new Faker("pt_BR");           

            var email = new Faker<Email>().CustomInstantiator((f) => new Email(faker.Internet.ExampleEmail())).Generate(1).First();
            var documento = new Faker<Documento>().CustomInstantiator((f) => new Documento(faker.Person.Cpf(true), EDocumentoTipo.CPF)).Generate(1).First();
            var nome =  new Faker<Nome>().CustomInstantiator((f) => new Nome(faker.Person.FirstName,faker.Person.LastName)).Generate(1).First();
            var nascimento = new Faker<Nascimento>().CustomInstantiator((f) => new Nascimento(faker.Person.DateOfBirth.AddYears(-18))).Generate(1).First();
            var endereco = new Faker<Endereco>().CustomInstantiator((f) => new Endereco(
                faker.Address.StreetSuffix(),
                faker.Address.BuildingNumber(),
                faker.Address.CitySuffix(),
                faker.Address.City(),
                faker.Address.State(),
                faker.Address.ZipCode())).Generate(1).First();

            clientes = new Faker<Cliente>()
                .CustomInstantiator((f) => new Cliente(nome, documento, endereco, email, nascimento )).Generate(5);

            clienteRepository = new Mock<IClienteRepository>();
        }


        [TestMethod]
        public void CriticaQuandoEmailInvalidoEmObterClientePorEmail()
        {
            var command = new ObterClientePorEmailCommand();
            command.Email = faker.Person.FirstName;

            var handler = new ClienteHandler(null);

            var result = handler.Handle(command);

            Assert.IsFalse(result.Success);
        }

        public void CriticaQuandoClienteNaoEncontrado()
        {
            clienteRepository.Setup(r => r.ObterClientePorEmail(clientes.First().Email.EnderecoEmail)).Returns((Cliente)null);

            var command = new ObterClientePorEmailCommand();
            command.Email = faker.Person.Email;

            var handler = new ClienteHandler(clienteRepository.Object);

            var result = handler.Handle(command);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Cliente não encontrado", result.Message);
        }

        [TestMethod]
        public void SucessoQuandoClienteEncontrado()
        {
            clienteRepository.Setup(r => r.ObterClientePorEmail(clientes.First().Email.EnderecoEmail)).Returns(clientes.First());
            var handler = new ClienteHandler(clienteRepository.Object);

            var command = new ObterClientePorEmailCommand();
            command.Email = clientes.First().Email.EnderecoEmail;

            var result = handler.Handle(command);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(clientes.First().Id, ((Cliente)result.Content).Id);
        }
    }
}