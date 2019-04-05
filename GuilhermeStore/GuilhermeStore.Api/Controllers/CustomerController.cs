using System;
using System.Collections.Generic;
using GuilhermeStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GuilhermeStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            // var customer
            return new List<Customer>();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            return null;
        }

        [HttpGet]
        [Route("customer/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            return null;
        }


        [HttpPost]
        [Route("customer")]
        public Customer Post([FromBody]Customer customer)
        {
            return null;
        }


        [HttpPut]
        [Route("customer/{id}")]
        public Customer Put([FromBody]Customer customer)
        {
            return null;
        }

        [HttpDelete]
        [Route("customer/{id}")]
        public string Delete()
        {
            return null;
        }

    }
}