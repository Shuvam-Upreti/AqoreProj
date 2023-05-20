 namespace Aqore.Models.Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int TotalAmount { get; set; }
    }
}
