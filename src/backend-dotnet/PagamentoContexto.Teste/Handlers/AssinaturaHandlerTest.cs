using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContexto.Dominio.Commands;
using PagamentoContexto.Dominio.Enums;
using PagamentoContexto.Dominio.Handlers;
using PagamentoContexto.Teste.Mocks;

namespace PagamentoContexto.Teste.Handlers
{
    [TestClass]
    public class AssinaturaHandlerTest
    {
        [TestMethod]
        public void DeveRetornarErroQuandoDocumentoExiste()
        {
            var handler = new AssinaturaHandler(
                new FakeEstudanteRepository(),
                new FakeEmailService()
            );

            var command = new AssinaturaBoletoCommand();
            command.PrimeiroNome = "Bruce";
            command.UltimoNome = "Wayne";
            command.Documento = "99999999999";
            command.Email = "hello@balta.io2";
            command.CodigoBarras = "123456789";
            command.NumeroBoleto = "2131213121";
            command.NumeroPagamento = "123121";
            command.DataPagamento = DateTime.Now;
            command.DataExpiracao = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPago = 60;
            command.Pagador = "WAYNE CORP";
            command.PagadorDocumento = "12345678911";
            command.PagadorDocumentoTipo = EDocumentoTipo.CPF;
            command.PagadorEmail = "batman@dc.com";
            command.Rua = "asdas";
            command.Numero = "asdas";
            command.Bairro = "asdas";
            command.Cidade = "as";
            command.Estado = "as";
            command.Pais = "as";
            command.CEP = "12345678";

            handler.Handle(command);
            Assert.IsTrue(handler.Valid, "Falha na execução dos testes do handler");

        }
    }
}