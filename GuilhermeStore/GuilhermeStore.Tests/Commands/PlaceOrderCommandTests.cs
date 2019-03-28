using GuilhermeStore.Domain.StoreContext.OrderCommands.Inputs;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GuilhermeStore.Tests.Commands
{
    [TestClass]
    public class PlaceOrderCommmandTests
    {

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new PlaceOrderCommand();
            command.Customer = Guid.NewGuid();

            var item = new OrderItemCommand();
            item.Product = Guid.NewGuid();
            item.Quantity = 10;

            command.OrderItems.Add(item);


            Assert.AreEqual(true, item.Valid());
            Assert.AreEqual(true, command.Valid());

        }

    }
}
