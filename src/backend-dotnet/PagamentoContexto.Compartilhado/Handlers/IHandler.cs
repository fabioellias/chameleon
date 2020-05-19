
using PagamentoContexto.Compartilhado.Commands;

namespace PagamentoContexto.Compartilhado.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}