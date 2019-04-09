using System;
using FluentValidator;
using FluentValidator.Validation;
using GuilhermeStore.Shared.Commands;

namespace GuilhermeStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class DeleteCustomerCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                .AreEquals(Id, null, "Id", "O Id do usuário não pode ser núlo."));
            return IsValid;
        }

    }
}