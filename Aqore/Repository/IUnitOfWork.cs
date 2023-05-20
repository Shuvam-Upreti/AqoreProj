namespace Aqore.Repository
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICustomerRepository Customer { get; }
        ISalesRepository Sales { get; }
        IInvoiceRepository Invoice { get; }
    }
}
