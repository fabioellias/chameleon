using Loja.Shared.Commands;
using Loja.Shared.Commands.Types;

namespace Loja.Shared.Handlers
{
  public interface IHandler<T> where T : ICommand
    {
        CommandResult Handle(T command);
    }
}