namespace WebApplication1.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        //Stok miktarı belli bir sayı altına düşülürse tutulacak değer.
        public bool Threshold { get; set; }
        public string ProductImage { get; set; }
        //Navigation prop
        public Category Category { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
