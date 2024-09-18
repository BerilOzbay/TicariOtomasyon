namespace WebApplication1.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string PersonnelName { get; set; }
        public string PersonnelSurname { get; set; }
        public string PersonnelImage { get; set; }
        //Navigation Prop
        public Department Department { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
