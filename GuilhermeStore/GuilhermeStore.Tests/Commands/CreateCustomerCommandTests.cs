using GuilhermeStore.Domain.StoreContext.CustomerCommands.Inputs;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuilhermeStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Guilherme";
            command.LastName = "Ramos Mendes";
            command.Document = "11950265609";
            command.Email = "guilherme.mendes@interplayers.com.br";
            command.Phone = "11987179324";
         
            Assert.AreEqual(true, command.Valid());
        }

    }
}
