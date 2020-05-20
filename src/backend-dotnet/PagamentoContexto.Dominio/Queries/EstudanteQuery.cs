using System;
using System.Linq.Expressions;
using PagamentoContexto.Dominio.Entidades;

namespace PagamentoContexto.Dominio.Queries
{
    public static class EstudanteQuery
    {
        public static Expression<Func<Estudante, bool>> ObterEstudante(string documento){
           return x => x.Documento.Numero == documento;
        }
    }
}