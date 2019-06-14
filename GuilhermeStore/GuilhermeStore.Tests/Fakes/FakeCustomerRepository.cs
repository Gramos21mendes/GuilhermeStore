using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuilhermeStore.Domain.StoreContext.CustomerCommands.Inputs;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.Handlers;
using GuilhermeStore.Domain.StoreContext.Queries;
using GuilhermeStore.Domain.StoreContext.Repositories;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuilhermeStore.Tests.Fakes
{

    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public Task<CustomerOrdersCountResult> GetCustomerOrdersCount(string document)
        {
            return null;
        }

        public void Save(Customer customer)
        {

        }

        public Task<IEnumerable<ListCustomerQueryResult>> Get()
        {
            return null;
        }


        public Task<GetCustomerQueryResult> Get(Guid id)
        {
            return null;
        }

        public async Task<IEnumerable<ListCustomerOrdersQueryResult>> GetOrders(Guid id)
        {
            return null;
        }

        public void EditCustomer(Guid id, string document, string firstName, string lastName, string email)
        {

        }

        public void Delete(Guid id)
        {

        }

        public bool CheckCustomer(Guid id)
        {
            return false;
        }
    }
}
