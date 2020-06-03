using Loja.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Test.Unit.ValueObjects
{
    [TestClass]
    public class PrecoTest
    {
        [TestMethod]
        public void CriticaQuandoPrecoNegativo(){
            var preco = new Preco(-10);

            //Assert.IsFalse(preco.Valid);
            Assert.IsTrue(preco.Invalid);
        }

        [TestMethod]
        public void SucessoQuandoPrecoMaiorOuIgualZero(){
            var preco = new Preco(59);

            Assert.IsTrue(preco.Valid);
        }        
    }
}