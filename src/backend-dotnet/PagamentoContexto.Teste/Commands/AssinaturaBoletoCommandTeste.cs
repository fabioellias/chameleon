using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContexto.Dominio.Commands;

namespace PagamentoContexto.Teste.Commands
{
    [TestClass]
    public class AssinaturaBoletoCommandTeste
    {
        [TestMethod]
        public void DeveRetornarErroQuandoNomeInvalido()
        {
            var commando = new AssinaturaBoletoCommand();
            commando.PrimeiroNome = string.Empty;

            commando.Validate();
            Assert.IsFalse(commando.Valid);
        }
    }
}