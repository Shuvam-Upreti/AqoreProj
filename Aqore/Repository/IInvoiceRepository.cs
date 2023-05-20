using Aqore.Models.Domain;

namespace Aqore.Repository
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> InvoicesFromStoredProcedure();
        IEnumerable<Invoice> InvoiceFromStoredProcedure(int invoiceId);
        void CreateInvoice(DateTime date, int amount);
        void UpdateInvoice(DateTime date, int amount);
        void DeleteInvoice(int invoiceId);
    }
}
