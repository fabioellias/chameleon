using System.Reflection;
using Loja.Domain.Enums;
using Loja.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Test.Unit.ValueObjects
{
    [TestClass]
    public class DocumentoTest
    {

        [TestMethod]
        public void CriticaQuandoCPFInvalido(){
            var documento = new Documento("123", EDocumentoTipo.CPF);

            Assert.IsFalse(documento.Valid);
        }        

        [TestMethod]
        public void SucessoQuandoCPFValido(){
            var documento = new Documento("625.004.100-13", EDocumentoTipo.CPF);

            Assert.IsTrue(documento.Valid);
        }        
    }
}