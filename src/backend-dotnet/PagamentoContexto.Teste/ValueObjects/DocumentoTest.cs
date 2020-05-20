using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContexto.Dominio.Enums;
using PagamentoContexto.Dominio.ValueObjects;

namespace PagamentoContexto.Teste.ValueObjects
{
    [TestClass]
    public class DocumentoTest
    {
        //Red, Green, Refactor

        [TestMethod]
        public void DeveRetornarErroQuandoCNPJInvalido()
        {
            var doc = new Documento("1234", EDocumentoTipo.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoCNPJValido()
        {
            var doc = new Documento("83802400000148", EDocumentoTipo.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoCPFInvalido()
        {
            var doc = new Documento("1234", EDocumentoTipo.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [
        TestMethod]
        [DataTestMethod]
        [DataRow("95779090009")]
        [DataRow("07589621345")]
        [DataRow("12345678901")]
        public void DeveRetornarSucessoQuandoCPFValido(string cpf)
        {
            var doc = new Documento(cpf, EDocumentoTipo.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}