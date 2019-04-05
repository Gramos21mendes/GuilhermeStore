using System;
using System.Collections.Generic;
using GuilhermeStore.Domain.StoreContext.CustomerCommands.Inputs;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace GuilhermeStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {

            var name = new Name("Guilherme", "Ramos Mendes");
            var document = new Document("11950265609");
            var email = new Email("guilherme.mendes@interplayers.com.br");
            var customer = new Customer(name, document, email, "1198717934");
            var customers = new List<Customer>();
            customers.Add(customer);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Guilherme", "Ramos Mendes");
            var document = new Document("11950265609");
            var email = new Email("guilherme.mendes@interplayers.com.br");
            var customer = new Customer(name, document, email, "1198717934");
            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("Guilherme", "Ramos Mendes");
            var document = new Document("11950265609");
            var email = new Email("guilherme.mendes@interplayers.com.br");
            var customer = new Customer(name, document, email, "11987179324");
            var order = new Order(customer);

            var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            var keyboard = new Product("Teclado Gamer", "Teclado Gamer", "keyboard.jpg", 100M, 10);

            order.AddItem(mouse, 5);
            order.AddItem(keyboard, 5);

            var orders = new List<Order>();

            orders.Add(order);

            return orders;
        }


        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }


        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente Removido com Sucesso !" };
        }

    }
}