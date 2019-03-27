using GuilhermeStore.Domain.StoreContext.OrderCommands.Inputs;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuilhermeStore.Tests.Commands
{
    [TestClass]
    public class PlaceOrderCommmandTests
    {

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new PlaceOrderCommand();
            command.Customer = new System.Guid();

            var item = new OrderItemCommand();
            item.Product = new System.Guid();
            item.Quantity = 10;

            command.OrderItems.Add(item);


            Assert.AreEqual(true, item.Valid());
            Assert.AreEqual(true, command.Valid());

        }

    }
}
