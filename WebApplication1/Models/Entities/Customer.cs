namespace WebApplication1.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerEmail { get; set; }
        //Navigation Prop
        public ICollection<Sale> Sales { get; set; }
    }
}
