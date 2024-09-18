namespace WebApplication1.Models.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string ItemNumber { get; set; }
        public DateTime Date { get; set; }
        public string TaxOffice { get; set; }
        public string Recipient { get; set; }
        public string Consigner { get; set; }
        public ICollection<BillItem> BillItems { get; set; }
    }
}
