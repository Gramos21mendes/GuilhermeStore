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
    public class CustomerHandler : Notifiable, ICommandHanler<CreateCustomerCommand>, ICommandHanler<AddAddressCommand>, ICommandHanler<EditCustomerCommand>, ICommandHanler<DeleteCustomerCommand>
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

            if (Invalid) return new CommandResult(false, "Por favor, corrija os campos abaixo.", Notifications);

            //Persistir o cliente 
            _repository.Save(customer);

            // //Enviar um E-mail de boas vindas
            // _emailService.Send(email.Address, "guilherme.mendes@interlayers.com.br", "Bem Vindo", "Seja Bem vindo ao Guilherme Store!");

            //Retornar o resultado para tela
            return new CommandResult(true, "Bem-Vindo ao Guilherme Store", new { Id = customer.Id, Name = name.ToString(), Email = email.Address });
        }


        public ICommandResult Handle(EditCustomerCommand command)
        {

            if (!_repository.CheckCustomer(command.Id))
                AddNotification("Cliente", "O Cliente não existe.");

            //Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Validar Entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);

            if (Invalid) return new CommandResult(false, "Não foi possível editar os dados", Notifications);

            //edita dados do usuário.
            _repository.EditCustomer(command.Id, document.Number, name.FirstName, name.LastName, email.Address);

            // //Enviar um E-mail avisando alteração.
            // _emailService.Send(email.Address, "guilherme.mendes@interlayers.com.br", "Alteração de dados", "Seus dados foram Atualizados.");

            return new CommandResult(true, "Informações Editadas com Sucesso !");
        }


        public ICommandResult Handle(DeleteCustomerCommand command)
        {
            //Verificar se o CPF já existe na base
            if (!_repository.CheckCustomer(command.Id))
                AddNotification("Cliente", "O Cliente não existe.");

            AddNotifications(command.Notifications);

            if (Invalid) return new CommandResult(false, "Não foi posível realizar a exclusão.", Notifications);

            _repository.Delete(command.Id);

            return new CommandResult(true, "Exclusão realizada com sucesso !");
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }


    }
}