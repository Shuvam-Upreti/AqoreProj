using Aqore.Data;
using Aqore.Models.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Aqore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> CustomersFromStoredProcedure()
        {
            return _context.Customers.FromSqlRaw("EXEC GetCustomers");
        }

        public IEnumerable<Customer> CustomerFromStoredProcedure(int customerId)
        {
            var parameter = new SqlParameter("@customerId", customerId);
            return _context.Customers.FromSqlRaw("EXEC GetCustomerById @customerId", parameter);
        }

        public void CreateCustomer(string name, string address)
        {
            var nameParameter = new SqlParameter("@name", name);
            var addressParameter = new SqlParameter("@address", address);
            _context.Customers.FromSqlRaw("EXEC CreateProduct @name, @address", nameParameter, addressParameter);
        }

        public void UpdateCustomer(string name, string address)
        {
            var nameParameter = new SqlParameter("@name", name);
            var addressParameter = new SqlParameter("@address", address);
            //var priceParameter = new SqlParameter("@price", price);
            //var inStockParameter = new SqlParameter("@inStock", inStock);

             _context.Products.FromSqlRaw("EXEC UpdateProduct @name, @address", nameParameter, addressParameter);
        }

        public void DeleteCustomer(int customerId)
        {
            var customerIdParameter = new SqlParameter("@customerId", customerId);
             _context.Products.FromSqlRaw("EXEC DeleteCustomer @customerId", customerIdParameter);
        }

    }
}



