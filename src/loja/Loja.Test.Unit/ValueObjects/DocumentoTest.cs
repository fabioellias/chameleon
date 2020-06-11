using System.Reflection;
using Bogus;
using Bogus.Extensions.Brazil;
using Loja.Domain.Enums;
using Loja.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Test.Unit.ValueObjects
{
    [TestClass]
    public class DocumentoTest
    {
        private Faker faker;

        [TestInitialize]
        public void Setup()
        {
            faker = new Faker("pt_BR");
        }

        [TestMethod]
        public void CriticaQuandoCPFInvalido()
        {
            var documento = new Documento(faker.Random.Int().ToString(), EDocumentoTipo.CPF);

            Assert.IsFalse(documento.Valid);
        }

        [TestMethod]
        public void SucessoQuandoCPFValido()
        {
            var documento = new Documento(faker.Person.Cpf(), EDocumentoTipo.CPF);

            Assert.IsTrue(documento.Valid);
        }
    }
}