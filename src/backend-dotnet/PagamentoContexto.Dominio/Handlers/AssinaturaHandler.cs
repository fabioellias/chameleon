using System;
using Flunt.Notifications;
using PagamentoContexto.Compartilhado.Commands;
using PagamentoContexto.Compartilhado.Handlers;
using PagamentoContexto.Dominio.Commands;
using PagamentoContexto.Dominio.Entidades;
using PagamentoContexto.Dominio.Enums;
using PagamentoContexto.Dominio.Repositories;
using PagamentoContexto.Dominio.Services;
using PagamentoContexto.Dominio.ValueObjects;

namespace PagamentoContexto.Dominio.Handlers
{
    public class AssinaturaHandler : Notifiable, 
        IHandler<AssinaturaBoletoCommand>,
        IHandler<AssinaturaPayPalCommand>,
        IHandler<AssinaturaCartaoCreditoCommand>
    {

        private readonly IEstudanteRepository estudanteRepository;
        private readonly IEmailService emailService; 

        public AssinaturaHandler(IEstudanteRepository estudanteRepository, IEmailService emailService)
        {
            this.estudanteRepository = estudanteRepository;
            this.emailService = emailService;
        }
        public ICommandResult Handle(AssinaturaBoletoCommand command)
        {
            //fail fast validations
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");
            }

            //Verificar se documento ja esta cadastrado
            if (estudanteRepository.DocumentoExiste(command.Documento))
            {
                AddNotification("Documento", "Este CPF já está em uso");
            }

            //verificar se email ja esta cadastrado
            if (estudanteRepository.EmailExiste(command.Documento))
            {
                AddNotification("Email", "Este E-mail já está em uso");
            }

            //gerar os vos
            var nome = new Nome(command.PrimeiroNome, command.UltimoNome);
            var documento = new Documento(command.Documento, EDocumentoTipo.CPF);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Pais, command.CEP);

            //gerar as entidades
            var estudante = new Estudante(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new Boleto(
                command.CodigoBarras,
                command.NumeroBoleto,
                command.DataPagamento,
                command.DataExpiracao,
                command.Total,
                command.TotalPago,
                command.Pagador,
                new Documento(command.PagadorDocumento, command.PagadorDocumentoTipo),
                endereco,
                email);

            //relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            estudante.AdicionarAssinatura(assinatura);

            //agrupar as validações
            AddNotifications(nome, documento, email, endereco, estudante, assinatura, pagamento);

            //salvar as informações
            estudanteRepository.CriarAssinatura(estudante);

            //enviar email de boas vindas
            emailService.Send(estudante.Nome.ToString(), estudante.Email.EnderecoEmail, "Bem vindo ao serviço de assinatura", "Sua assinatura foi criada com sucesso.");
            
            //retornar as informações
            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
        public ICommandResult Handle(AssinaturaPayPalCommand command)
        {
            //fail fast validations
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");
            }

            //Verificar se documento ja esta cadastrado
            if (estudanteRepository.DocumentoExiste(command.Documento))
            {
                AddNotification("Documento", "Este CPF já está em uso");
            }

            //verificar se email ja esta cadastrado
            if (estudanteRepository.EmailExiste(command.Documento))
            {
                AddNotification("Email", "Este E-mail já está em uso");
            }

             //gerar os vos
            var nome = new Nome(command.PrimeiroNome, command.UltimoNome);
            var documento = new Documento(command.Numero, EDocumentoTipo.CPF);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Pais, command.CEP);

            //gerar as entidades
            var estudante = new Estudante(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new PayPal(
                command.CodigoTransacao,                
                command.DataPagamento,
                command.DataExpiracao,
                command.Total,
                command.TotalPago,
                command.Pagador,
                new Documento(command.PagadorDocumento, command.PagadorDocumentoTipo),
                endereco,
                email);

            //relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            estudante.AdicionarAssinatura(assinatura);

            //agrupar as validações
            AddNotifications(nome, documento, email, endereco, estudante, assinatura, pagamento);

            if(Invalid)
                return new CommandResult(false, "Não foi possível realizar a sua assinatura");

            //salvar as informações
            estudanteRepository.CriarAssinatura(estudante);

            //enviar email de boas vindas
            emailService.Send(estudante.Nome.ToString(), estudante.Email.EnderecoEmail, "Bem vindo ao serviço de assinatura", "Sua assinatura foi criada com sucesso.");
            
            //retornar as informações
            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }

        public ICommandResult Handle(AssinaturaCartaoCreditoCommand command)
        {
            //fail fast validations
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");
            }

            //Verificar se documento ja esta cadastrado
            if (estudanteRepository.DocumentoExiste(command.Documento))
            {
                AddNotification("Documento", "Este CPF já está em uso");
            }

            //verificar se email ja esta cadastrado
            if (estudanteRepository.EmailExiste(command.Documento))
            {
                AddNotification("Email", "Este E-mail já está em uso");
            }

             //gerar os vos
            var nome = new Nome(command.PrimeiroNome, command.UltimoNome);
            var documento = new Documento(command.Numero, EDocumentoTipo.CPF);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Pais, command.CEP);

            //gerar as entidades
            var estudante = new Estudante(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new CartaoCredito(
                command.NomeNoCartao,                
                command.NumeroCartao,
                command.NumeroUltimaTransacao,
                command.DataPagamento,
                command.DataExpiracao,
                command.Total,
                command.TotalPago,
                command.Pagador,
                new Documento(command.PagadorDocumento, command.PagadorDocumentoTipo),
                endereco,
                email);

            //relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            estudante.AdicionarAssinatura(assinatura);

            //agrupar as validações
            AddNotifications(nome, documento, email, endereco, estudante, assinatura, pagamento);

            //salvar as informações
            estudanteRepository.CriarAssinatura(estudante);

            //enviar email de boas vindas
            emailService.Send(estudante.Nome.ToString(), estudante.Email.EnderecoEmail, "Bem vindo ao serviço de assinatura", "Sua assinatura foi criada com sucesso.");
            
            //retornar as informações
            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
    }
}