using Flunt.Notifications;
using Loja.Domain.Repositories;
using Loja.Shared.Commands;
using Loja.Shared.Commands.Types;
using Loja.Shared.Handlers;

namespace Loja.Domain.Handlers
{
    public class ProdutoHandler : Notifiable, IHandler<ListarProdutoParaVendaCommand>
    {
        private readonly IProdutoRepository produtoRepository;
        public ProdutoHandler(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        //ListarProdutoParaVendaCommand
        public CommandResult Handle(ListarProdutoParaVendaCommand command)
        {
            var produtos = produtoRepository.ListarProdutoParaVenda();
            return new CommandResult(true, "", produtos);
        }
    }
}