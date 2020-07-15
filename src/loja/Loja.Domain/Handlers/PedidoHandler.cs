using System.Collections.Generic;
using Flunt.Notifications;
using Loja.Domain.Entities;
using Loja.Domain.Repositories;
using Loja.Shared.Commands;
using Loja.Shared.Commands.Types;
using Loja.Shared.Handlers;

namespace Loja.Domain.Handlers
{
    public class PedidoHandler : Notifiable, IHandler<CriarPedidoCommand>, IHandler<MeusPedidosCommand>
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly IProdutoRepository produtoRepository;

        public PedidoHandler(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository, IProdutoRepository produtoRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.clienteRepository = clienteRepository;
            this.produtoRepository = produtoRepository;
        }

        public CommandResult Handle(CriarPedidoCommand command)
        {
            var produtos = new List<Produto>();

            var cliente = clienteRepository.ObterClientePorEmail(command.EmailCliente);

            var pedido = new Pedido(cliente);

            foreach (var item in command.Itens)
            {
                var produto = produtoRepository.ObterProdutoPorCodigo(item.CodigoProduto);
                pedido.IncluirItem(produto, item.Quantidade);
            }

            if (pedido.Invalid)
                return new CommandResult(pedido.Notifications, command);

            var pedidoCriado = pedidoRepository.Criar(pedido);

            return new CommandResult(true, "Pedido criado com sucesso", pedidoCriado);
        }

        public CommandResult Handle(MeusPedidosCommand command)
        {
            var pedidos = pedidoRepository.MeusPedidos(command.EmailCliente);
            return new CommandResult(true, "", pedidos);
        }
    }
}