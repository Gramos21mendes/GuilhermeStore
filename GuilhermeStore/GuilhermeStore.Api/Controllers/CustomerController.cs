using System;
using System.Collections.Generic;
using GuilhermeStore.Domain.StoreContext.CustomerCommands.Inputs;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.Handlers;
using GuilhermeStore.Domain.StoreContext.Queries;
using GuilhermeStore.Domain.StoreContext.Repositories;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using GuilhermeStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace GuilhermeStore.Api.Controllers
{
    public class CustomerController : Controller
    {

        //Para versionamento de api's, pode-se colocar v1, v2, v3 etc nas rotas.
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        // [ResponseCache(Duration = 60)] Cache, se os dados forem muito mutáveis não compensa.
        // Location =  ResponseCacheLocation.Client
        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get() => _repository.Get();

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id) => _repository.Get(id);

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id) => _repository.GetOrders(id);


        [HttpPost]
        [Route("customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command) => (ICommandResult)_handler.Handle(command);

        //customers/{id} - Padrão
        [HttpPut]
        [Route("customers")]
        public ICommandResult Put([FromBody]EditCustomerCommand command) => (ICommandResult)_handler.Handle(command);

        //customers/{id} - Padrão
        [HttpDelete]
        [Route("customers")]
        public ICommandResult Delete([FromBody]DeleteCustomerCommand command) => (ICommandResult)_handler.Handle(command);

    }
}