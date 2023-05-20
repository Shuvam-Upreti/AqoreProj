using Aqore.Data;
using Aqore.Models.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace Aqore.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Invoice> InvoicesFromStoredProcedure()
        {
            return _context.Invoices.FromSqlRaw("EXEC GetInvoices");
        }

        public IEnumerable<Invoice> InvoiceFromStoredProcedure(int invoiceId)
        {
            var parameter = new SqlParameter("@invoiceId", invoiceId);
            return _context.Invoices.FromSqlRaw("EXEC GetInvoiceById @invoiceId", parameter);
        }

        public void CreateInvoice(DateTime date, int amount)
        {
            var dateParameter = new SqlParameter("@date", date);
            var amountParameter = new SqlParameter("@amount", amount);
            _context.Invoices.FromSqlRaw("EXEC CreateInvoice @date, @amount", dateParameter, amountParameter);
        }

        public void UpdateInvoice(DateTime date, int amount)
        {
            var dateParameter = new SqlParameter("@date", date);
            var amountParameter = new SqlParameter("@amount", amount);
            _context.Invoices.FromSqlRaw("EXEC UpdateInvoice @date, @amount", dateParameter, amountParameter);
        }

        public void DeleteInvoice(int invoiceId)
        {
            var invoiceIdParameter = new SqlParameter("@invoiceId", invoiceId);
             _context.Products.FromSqlRaw("EXEC DeleteCustomer @customerId", invoiceIdParameter);
        }

    }
}



