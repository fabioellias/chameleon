using System.Runtime.CompilerServices;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContexto.Dominio.Entidades;
using PagamentoContexto.Dominio.Enums;
using PagamentoContexto.Dominio.ValueObjects;

namespace PagamentoContexto.Teste.Entidades
{
    [TestClass]
    public class EstudanteTest
    {
        private readonly Nome nome;
        private readonly Documento documento;
        private readonly Endereco endereco;
        private readonly Email email;
        private readonly Estudante estudante;
        private readonly Assinatura assinatura;
        public EstudanteTest()
        {
            nome = new Nome("Bruce", "Wayne");
            documento = new Documento("12456412121", EDocumentoTipo.CPF);
            email = new Email("ola@batman.com");
            endereco = new Endereco("Rua 1", "123", "Rocha Miranda", "Rio de Janeiro", "RJ", "Brasil", "22510456");
            estudante = new Estudante(nome, documento, email);
            assinatura = new Assinatura(null);
        }

        [TestMethod]
        public void DeveRetornarErroQuandoAssinaturaEstiverAtiva()
        {
            var pagamento = new PayPal("12345678", DateTime.Now, DateTime.Now.AddDays(6), 10, 10, "O Proprio", documento, endereco, email);
            assinatura.AdicionarPagamento(pagamento);

            estudante.AdicionarAssinatura(assinatura);
            estudante.AdicionarAssinatura(assinatura);

            Assert.IsTrue(estudante.Invalid);
        }

        [TestMethod]
        public void DeveRetornarErroQuandoAssinaturaNaoTiverPagamento()
        {
            estudante.AdicionarAssinatura(assinatura);
            Assert.IsTrue(estudante.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoAssinaturaNaoEstiverAtiva()
        {

            var pagamento = new PayPal("12345678", DateTime.Now, DateTime.Now.AddDays(6), 10, 10, "O Proprio", documento, endereco, email);
            assinatura.AdicionarPagamento(pagamento);
            estudante.AdicionarAssinatura(assinatura);

            Assert.IsTrue(estudante.Valid);

        }

    }
}