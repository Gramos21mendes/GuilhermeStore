using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.Queries;
using GuilhermeStore.Domain.StoreContext.Repositories;
using GuilhermeStore.Infra.StoreContext.DataContexts;

namespace GuilhermeStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly GuilhermeDataContext _context;

        public CustomerRepository(GuilhermeDataContext context)
        {
            _context = context;
        }
        public bool CheckDocument(string document) =>
             _context.Connection.Query<bool>(
                "spCheckDocument",
                new { Document = document },
                 commandType: CommandType.StoredProcedure).FirstOrDefault();


        public bool CheckEmail(string email) =>
        _context.Connection.Query<bool>(
                "spCheckEmail",
                new { Email = email },
                 commandType: CommandType.StoredProcedure)
                 .FirstOrDefault();


        public IEnumerable<ListCustomerQueryResult> Get() =>
        _context.Connection.Query<ListCustomerQueryResult>("spListCustomer", commandType: CommandType.StoredProcedure);

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document) =>
        _context.Connection.Query<CustomerOrdersCountResult>(
                "spGetCustomerOrdersCount",
                new { Document = document },
                 commandType: CommandType.StoredProcedure)
                 .FirstOrDefault();

        public GetCustomerQueryResult Get(Guid id) =>
            _context.Connection.Query<GetCustomerQueryResult>(
                "spListCustomerId",
                new { Id = id },
                 commandType: CommandType.StoredProcedure).FirstOrDefault();

        //TODO : Fazer Procedure para listar os pedidos do Cliente.
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id) =>
            _context.Connection.Query<ListCustomerOrdersQueryResult>("spCustomerGetOrders", commandType: CommandType.StoredProcedure);

        public void Save(Customer customer)
        {
            _context.Connection.Execute(
               "spCreateCustomer",
               new
               {
                   Id = customer.Id,
                   FirstName = customer.Name.FirstName,
                   LastName = customer.Name.LastName,
                   Document = customer.Document.ToString(),
                   Email = customer.Email.Address,
                   Phone = customer.Phone,
                   RegisterDate = DateTime.Now,
                   AlterationDate = DateTime.Now

               },
                commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress", new
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    RegisterDate = DateTime.Now,
                    Type = address.Type,
                }, commandType: CommandType.StoredProcedure);
            }

        }

        public void EditCustomer(Guid id, string document, string firstName, string lastName, string email) =>
            _context.Connection.Execute(
               "spEditCustomer",
               new
               {
                   Id = id,
                   Document = document,
                   FirstName = firstName,
                   LastName = lastName,
                   Email = email,
                   AlterationDate = DateTime.Now
               },
                commandType: CommandType.StoredProcedure);

        public void Delete(Guid id) => _context.Connection.Execute(
                "spDeleteCustomer",
                new { Id = id },
                 commandType: CommandType.StoredProcedure);

        public bool CheckCustomer(Guid id) =>

            _context.Connection.Query<bool>(
                "spCheckCustomer",
                new { Id = id },
                 commandType: CommandType.StoredProcedure)
                 .FirstOrDefault();

    }
}