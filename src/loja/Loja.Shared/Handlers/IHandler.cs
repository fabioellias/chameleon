using Loja.Shared.Commands;

namespace Loja.Shared.Handlers
{
  public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}