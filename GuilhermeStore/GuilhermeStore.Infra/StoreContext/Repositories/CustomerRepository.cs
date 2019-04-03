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
        public bool CheckDocument(string document)
        {
            // var parameter = new DynamicParameters();

            // parameter.Add("@Document", document);

            return _context.Connection.Query<bool>(
                "spCheckDocument",
                new { Document = document },
                 commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            // var parameter = new DynamicParameters();

            // parameter.Add("@Email", email);

            return _context.Connection.Query<bool>(
                "spCheckDocument",
                new { Email = email },
                 commandType: CommandType.StoredProcedure)
                 .FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context.Connection.Query<CustomerOrdersCountResult>(
                "spGetCustomerOrdersCount",
                new { Document = document },
                 commandType: CommandType.StoredProcedure)
                 .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute(
               "spCreateCustomer",
               new
               {
                   Id = customer.Id,
                   FirstName = customer.Name.FirstName,
                   LastName = customer.Name.LastName,
                   Document = customer.Document,
                   Email = customer.Email.Address,
                   Phone = customer.Phone
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
                    Type = address.Type,
                }, commandType: CommandType.StoredProcedure);
            }

        }
    }
}