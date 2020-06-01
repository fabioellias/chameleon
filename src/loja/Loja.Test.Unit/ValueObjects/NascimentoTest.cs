using System;
using Loja.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Test.Unit.ValueObjects
{
    [TestClass]
    public class NascimentoTest
    {
        [TestMethod]
        public void CriticaQuandoTemMenosDe18Anos(){
            var nascimento = new Nascimento(DateTime.Now);

            Assert.IsTrue(nascimento.Invalid);
        }

        [TestMethod]
        public void SucessoQuandoMaiorDe18Anos(){
            var nascimento = new Nascimento(DateTime.Now.AddYears(-18));

            Assert.IsTrue(nascimento.Valid);
        }        
    }
}