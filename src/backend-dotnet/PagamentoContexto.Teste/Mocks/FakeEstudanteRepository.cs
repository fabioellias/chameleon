using PagamentoContexto.Dominio.Entidades;
using PagamentoContexto.Dominio.Repositories;

namespace PagamentoContexto.Teste.Mocks
{
    public class FakeEstudanteRepository : IEstudanteRepository
    {
        public void CriarAssinatura(Estudante aluno)
        {
            
        }

        public bool DocumentoExiste(string documento)
        {
            if (documento == "12345678901")
                return true;
            return false;
        }

        public bool EmailExiste(string email)
        {
            if (email == "usuario@email.com.br")
                return true;
            return false;
        }
    }
}