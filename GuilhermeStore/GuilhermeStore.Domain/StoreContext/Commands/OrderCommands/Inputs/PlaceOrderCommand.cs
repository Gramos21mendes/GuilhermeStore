using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using GuilhermeStore.Shared.Commands;

namespace GuilhermeStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado"));

            return IsValid;
        }
    }
}