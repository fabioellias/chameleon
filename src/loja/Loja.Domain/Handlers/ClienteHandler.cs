using System.Linq;
using Flunt.Notifications;
using Loja.Domain.Repositories;
using Loja.Domain.ValueObjects;
using Loja.Shared.Commands;
using Loja.Shared.Commands.Types;
using Loja.Shared.Handlers;

namespace Loja.Domain.Handlers
{
    public class ClienteHandler : Notifiable, IHandler<ObterClientePorEmailCommand>
    {
        private readonly IClienteRepository clienteRepository;
        public ClienteHandler(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        //ListarProdutoParaVendaCommand
        public CommandResult Handle(ObterClientePorEmailCommand command)
        {
            var email = new Email(command.Email);

            if (email.Invalid)
                return new CommandResult(false, email.Notifications.First().Message, null);

            var cliente = clienteRepository.ObterClientePorEmail(command.Email);

            if (cliente == null)
                return new CommandResult(false, "Cliente não encontrado.", null);

            return new CommandResult(true, "", cliente);
        }
    }
}