using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.Enums;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuilhermeStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Order _order;
        private Customer _customer;

        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;

        public OrderTests()
        {
            var name = new Name("Guilherme", "Ramos Mendes");
            var document = new Document("11950265609");
            var email = new Email("guilherme.mendes@interplayers.com.br");
            _customer = new Customer(name, document, email, "11987179324");
            _order = new Order(_customer);

            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado Gamer", "Teclado Gamer", "keyboard.jpg", 100M, 10);
            _chair = new Product("Chair Gamer", "Chair Gamer", "chair.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "monitor.jpg", 100M, 10);
        }
        // Consigo criar um novo pedido.
        [TestMethod]
        public void ShouldCreateOrerWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }
        // Ao criar o Pedio o status deve ser created.
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_keyboard, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrair a quantidade do produto.
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // Ao confirmar pedido, deve gerar um número.    
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar um pedido, o status deve ser pago
        [TestMethod]
        public void StatusShouldBePaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }


        // Dados mais 10 produtos, devem haver duas entregas.
        [TestMethod]
        public void ShouldTwoWhenPurchasedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        //Ao cancelar o pedido, o status deve ser cancelado.
        [TestMethod]
        public void StatusShpuldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        //Ao cancelar o pedido, deve cancelar as entregas.
        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }

    }
}
