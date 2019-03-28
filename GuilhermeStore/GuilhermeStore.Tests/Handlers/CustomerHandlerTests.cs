using GuilhermeStore.Domain.StoreContext.CustomerCommands.Inputs;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.Handlers;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using GuilhermeStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuilhermeStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Guilherme";
            command.LastName = "Ramos Mendes";
            command.Document = "11950265609";
            command.Email = "guilherme.mendes@interplayers.com.br";
            command.Phone = "11987179324";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}
