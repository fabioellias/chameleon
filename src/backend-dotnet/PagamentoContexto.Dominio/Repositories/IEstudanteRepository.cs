using PagamentoContexto.Dominio.Entidades;

namespace PagamentoContexto.Dominio.Repositories
{
    public interface IEstudanteRepository
    {
        bool DocumentoExiste(string documento);
        bool EmailExiste(string email);
        void CriarAssinatura(Estudante aluno);
    }
}