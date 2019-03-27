using System;
using FluentValidator;
using FluentValidator.Validation;
using GuilhermeStore.Shared.Commands;

namespace GuilhermeStore.Domain.StoreContext.OrderCommands.Inputs
{

    public class OrderItemCommand : Notifiable, ICommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasLen(Product.ToString(), 36, "Produtc", "Identificador do Produto Inválido")
                .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade inválida."));
                
            return IsValid;
        }
    }

}