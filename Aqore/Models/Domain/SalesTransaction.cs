namespace Aqore.Models.Domain
{
    public class SalesTransaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int SoldQuantity { get; set; }
    }
}
