using FluentValidator;
using FluentValidator.Validation;

namespace GuilhermeStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract().Requires()
                .IsEmail(Address, "Email", "O E-mail � inv�lido."));

        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}