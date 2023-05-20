using Aqore.Data;
using Aqore.Models.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Aqore.Repository
{
    public class SalesRepository : ISalesRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SalesTransaction> SalesTransactionsFromStoredProcedure()
        {
            return _context.SalesTransactions.FromSqlRaw("EXEC GetSalesTransactions");
        }

        public IEnumerable<SalesTransaction> SalesTransactionFromStoredProcedure(int salesId)
        {
            var parameter = new SqlParameter("@salesId", salesId);
            return _context.SalesTransactions.FromSqlRaw("EXEC GetSalesTransactionById @salesId", parameter);
        }

        public void CreateSalesTransaction(DateTime date, int quantity)
        {
            var dateParameter = new SqlParameter("@date", date);
            var quantityParameter = new SqlParameter("@quantity", quantity);
             _context.SalesTransactions.FromSqlRaw("EXEC CreateSalesTransaction @date, @quantity", dateParameter, quantityParameter);
        }

        public void UpdateSalesTransaction(DateTime date, int quantity)
        {
            var dateParameter = new SqlParameter("@date", date);
            var quantityParameter = new SqlParameter("@quantity", quantity);
            _context.SalesTransactions.FromSqlRaw("EXEC UpdateSalesTransaction @date, @quantity", dateParameter, quantityParameter);
        }

        public void DeleteSalesTransaction(int salesId)
        {
            var salesIdParameter = new SqlParameter("@salesId", salesId);
             _context.SalesTransactions.FromSqlRaw("EXEC DeleteSalesTransaction @salesId", salesIdParameter);
        }

    }
}



