using Flunt.Notifications;
using Loja.Domain.Repositories;
using Loja.Shared.Commands;
using Loja.Shared.Commands.Types;
using Loja.Shared.Handlers;

namespace Loja.Domain.Handlers
{
    public class ListarProdutoParaVendaHandler : Notifiable, IHandler<ListarProdutoParaVendaCommand>
    {
        private readonly IProdutoRepository produtoRepository;
        public ListarProdutoParaVendaHandler(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        //ListarProdutoParaVendaCommand
        public ICommandResult Handle(ListarProdutoParaVendaCommand command)
        {
            var produtos = produtoRepository.ListarProdutoParaVenda();
            return new CommandResult(true, "", produtos);
        }
    }
}