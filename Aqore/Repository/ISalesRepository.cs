using Aqore.Models.Domain;

namespace Aqore.Repository
{
    public interface ISalesRepository
    {
        IEnumerable<SalesTransaction> SalesTransactionsFromStoredProcedure();
        IEnumerable<SalesTransaction> SalesTransactionFromStoredProcedure(int salesId);
        void CreateSalesTransaction(DateTime date, int quantity);
        void UpdateSalesTransaction(DateTime date, int quantity);
        void DeleteSalesTransaction(int salesId);
    }
}
