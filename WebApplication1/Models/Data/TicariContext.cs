using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.Data
{
    public class TicariContext:DbContext
    {
        public TicariContext(DbContextOptions<TicariContext> options) :base(options) { }
      
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .HasMaxLength(30)
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Product>()
                .Property(p => p.Brand)
                .HasMaxLength(30)
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Admin>()
                .Property(p => p.Name)
                .HasMaxLength(10)
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Admin>()
               .Property(p => p.Password)
               .HasMaxLength(10)
               .HasColumnType("nvarchar");

            modelBuilder.Entity<Admin>()
               .Property(p => p.Authority)
               .HasMaxLength(1)
               .HasColumnType("char");

            modelBuilder.Entity<Customer>()
               .Property(p => p.CustomerName)
               .HasMaxLength(30)
               .HasColumnType("nvarchar");

            modelBuilder.Entity<Customer>()
               .Property(p => p.CustomerSurname)
               .HasMaxLength(30)
               .HasColumnType("nvarchar");

            modelBuilder.Entity<Customer>()
               .Property(p => p.CustomerCity)
               .HasMaxLength(15)
               .HasColumnType("nvarchar");

            modelBuilder.Entity<Customer>()
               .Property(p => p.CustomerEmail)
               .HasMaxLength(50)
               .HasColumnType("nvarchar");

            modelBuilder.Entity<Department>()
               .Property(p => p.DepartmentName)
               .HasMaxLength(30)
               .HasColumnType("nvarchar");

            modelBuilder.Entity<Bill>()
               .Property(p => p.SerialNumber)
               .HasMaxLength(1)
               .HasColumnType("char");





        }
    }
}
