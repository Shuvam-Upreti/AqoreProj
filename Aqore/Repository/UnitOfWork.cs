using Aqore.Data;
using Aqore.Models.Domain;

namespace Aqore.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Product = new ProductRepository(_context);
            Customer = new CustomerRepository(_context);
            Sales = new SalesRepository(_context);
            Invoice = new InvoiceRepository(_context);
        }
        public ICustomerRepository Customer { get; private set; }
        public IProductRepository Product { get; private set; }
        public ISalesRepository Sales { get; private set; }
        public IInvoiceRepository Invoice { get; private set; }

    }
}
