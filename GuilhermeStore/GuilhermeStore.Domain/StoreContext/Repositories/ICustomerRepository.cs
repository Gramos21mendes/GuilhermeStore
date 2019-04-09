using System;
using System.Collections.Generic;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.Queries;

namespace GuilhermeStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        bool CheckCustomer(Guid id);
        void Save(Customer customer);
        void Delete(Guid id);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
        void EditCustomer(Guid id, string document, string firstName,  string lastName, string email);
    }
}