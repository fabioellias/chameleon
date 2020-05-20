using System.IO.Enumeration;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContexto.Dominio.Entidades;
using PagamentoContexto.Dominio.Queries;
using PagamentoContexto.Dominio.ValueObjects;
using PagamentoContexto.Dominio.Enums;

namespace PagamentoContexto.Teste.Queries
{
    [TestClass]
    public class EstudanteQueryTest
    {
        private IList<Estudante> estudantes;

        public EstudanteQueryTest()
        {
            estudantes = new List<Estudante>();
            for (var i = 0; i <= 10; i++)
            {
                estudantes.Add(new Estudante(
                    new Nome("Aluno", i.ToString()),
                    new Documento("1234567890" + i.ToString(), EDocumentoTipo.CPF),
                    new Email(i.ToString() + "@balta.io")
                ));
            }
        }

        [TestMethod]
        public void DeveRetornarNuloQuandoDocumentoNaoExiste()
        {

            var exp = EstudanteQuery.ObterEstudante("12345678911");
            var estudante = estudantes.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, estudante);
        }

        [TestMethod]
        public void DeveRetornarEstudanteQuandoDocumentoExiste()
        {

            var exp = EstudanteQuery.ObterEstudante("12345678901");
            var estudante = estudantes.AsQueryable().Where(exp).FirstOrDefault();

            Assert.IsNotNull(estudante);
        }

    }
}