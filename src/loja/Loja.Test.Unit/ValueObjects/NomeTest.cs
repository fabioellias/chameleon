using System.Reflection;
using Loja.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Test.Unit.ValueObjects
{
    [TestClass]
    public class NomeTest
    {
        [TestMethod]
        public void CriticaQuandoTamanhoNomeInvalido()
        {
            var nomeCompleto = new Nome(null, null);

            Assert.IsTrue(nomeCompleto.Invalid);
        }

        [TestMethod]
        public void SucessoQuantoTamanhoNomeValido(){

            var nomeCompleto = new Nome("La", "Bamba");

            Assert.IsTrue(nomeCompleto.Valid);
        }
        
    }
}