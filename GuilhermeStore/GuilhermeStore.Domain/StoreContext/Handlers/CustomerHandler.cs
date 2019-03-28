using GuilhermeStore.Shared.Commands;
using GuilhermeStore.Domain.StoreContext.CustomerCommands.Inputs;
using FluentValidator;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using GuilhermeStore.Domain.StoreContext.Entities;
using System;
using GuilhermeStore.Domain.StoreContext.Repositories;
using GuilhermeStore.Domain.StoreContext.Services;

namespace GuilhermeStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHanler<CreateCustomerCommand>, ICommandHanler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF já existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se o E-mail existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Document", "Este E-mail já está em uso");

            //Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar Entidade
            var customer = new Customer(name, document, email, command.Phone);

            //Validar Entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid) return null;

            //Persistir o cliente 
            _repository.Save(customer);

            //Enviar um E-mail de boas vindas
            _emailService.Send(email.Address, "guilherme.mendes@interlayers.com.br", "Bem Vindo", "Seja Bem vindo ao Guilherme Store!");

            //Retornar o resultado para tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}