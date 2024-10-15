using WebApplication1.Models.Base;

namespace WebApplication1.Models.Entities
{
    public class Department:BaseEntity
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
