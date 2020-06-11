using System.Reflection;
using Bogus;
using Bogus.Extensions.Brazil;
using Loja.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Test.Unit.ValueObjects
{
    [TestClass]
    public class NomeTest
    {

        private Faker faker;

        [TestInitialize]
        public void Setup()
        {
            faker = new Faker("pt_BR");
        }

        [TestMethod]
        public void CriticaQuandoTamanhoNomeInvalido()
        {
            var nomeCompleto = new Nome(null, null);

            Assert.IsTrue(nomeCompleto.Invalid);
        }

        [TestMethod]
        public void SucessoQuantoTamanhoNomeValido()
        {
            var nomeCompleto = new Nome(faker.Person.FirstName, faker.Person.LastName);

            Assert.IsTrue(nomeCompleto.Valid);
        }

    }
}