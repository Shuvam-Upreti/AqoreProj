using Aqore.Models.Domain;

namespace Aqore.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> CustomersFromStoredProcedure();
        IEnumerable<Customer> CustomerFromStoredProcedure(int customerId);
        void CreateCustomer(string name, string address);
        void UpdateCustomer(string name, string address);
        void DeleteCustomer(int customerId);
    }
}
