namespace WebApplication1.Models.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        //Navigation Prop
        public Product Product { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
    }
}
