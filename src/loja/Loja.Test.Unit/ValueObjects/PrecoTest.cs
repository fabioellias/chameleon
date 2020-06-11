using Loja.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Loja.Test.Unit.ValueObjects
{
    [TestClass]
    public class PrecoTest
    {

        private Faker faker;

        [TestInitialize]
        public void Setup()
        {
            faker = new Faker("pt_BR");
        }

        [TestMethod]
        public void CriticaQuandoPrecoNegativo()
        {
            var preco = new Preco(faker.Random.Int(max : -1));

            //Assert.IsFalse(preco.Valid);
            Assert.IsTrue(preco.Invalid);
        }

        [TestMethod]
        public void SucessoQuandoPrecoMaiorOuIgualZero()
        {
            var preco = new Preco(faker.Random.Decimal());

            Assert.IsTrue(preco.Valid);
        }
    }
}