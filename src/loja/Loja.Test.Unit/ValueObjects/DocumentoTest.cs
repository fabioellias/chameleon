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
        public void CriticaQuandoCPFValido(){
            var documento = new Documento("123", EDocumentoTipo.CPF);

            Assert.IsFalse(documento.Valid);
        }        

        [TestMethod]
        public void SucessoQuandoCPFValido(){
            var documento = new Documento("12345678901", EDocumentoTipo.CPF);

            Assert.IsTrue(documento.Valid);
        }        
    }
}