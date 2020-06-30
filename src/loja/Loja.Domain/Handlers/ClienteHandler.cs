using System.Linq;
using Flunt.Notifications;
using Loja.Domain.Entities;
using Loja.Domain.Enums;
using Loja.Domain.Repositories;
using Loja.Domain.ValueObjects;
using Loja.Shared.Commands;
using Loja.Shared.Commands.Types;
using Loja.Shared.Handlers;

namespace Loja.Domain.Handlers
{
    public class ClienteHandler : Notifiable, IHandler<ObterClientePorEmailCommand>, IHandler<CadastrarClienteCommand>
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

        public CommandResult Handle(CadastrarClienteCommand command)
        {
            var nome = new Nome(command.PrimeiroNome, command.UltimoNome);
            var cpf = new Documento(command.CPF, EDocumentoTipo.CPF);
            var endereco = new Endereco(command.Logradouro, command.Numero, command.Bairro, command.Cidade, command.Estado, command.CEP);
            var email = new Email(command.Email);
            var nascimento = new Nascimento(command.Nascimento);

            AddNotifications(nome, cpf, endereco, email, nascimento);

            if (this.Invalid)
            {
                return new CommandResult(this.Notifications, command);
            }

            var cliente = new Cliente(nome, cpf, endereco, email, nascimento);

            clienteRepository.CadastrarCliente(cliente);

            return new CommandResult(true, "", cliente);
        }
    }
}