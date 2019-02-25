using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuilhermeStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //SIMULAR PEDIDO
            //(CLIENTE)
            var name = new Name("Guilherme", "Ramos Mendes");
            var document = new Document("119502565609");
            var email = new Email("119502565609");
            var c = new Customer(name, document, email, "56628921");

            //(PRODUTOS)
            var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "image.png", 159.90M, 10);
            var impressora = new Product("Impressora", "Impressora", "image.png", 359.90M, 10);
            var cadeira = new Product("Cadeira", "cadeira", "image.png", 559.90M, 10);

            //Criando e adicionando itens ao pedido
            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(teclado, 5));
            //order.AddItem(new OrderItem(impressora, 5));
            //order.AddItem(new OrderItem(cadeira, 5));

            //Realizar o Pedido
            order.Place();

            //Verificar se o pedido é valido
            var valid = order.IsValid;

            //Pagar o pedido
            order.Pay();

            //Enviar o pedido
            order.Ship();

            //Cancelar o pedido
            order.Cancel();

        }
    }
}
