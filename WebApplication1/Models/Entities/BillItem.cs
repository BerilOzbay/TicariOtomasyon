namespace WebApplication1.Models.Entities
{
    public class BillItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice{ get; set; }
        //Navigation Prop
        public Bill Bill { get; set; }
    }
}
