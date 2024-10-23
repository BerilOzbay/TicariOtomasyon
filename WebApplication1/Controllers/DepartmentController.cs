using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication1.Models.Data;
using WebApplication1.Models.Entities;


namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly TicariContext _context;

        public DepartmentController(TicariContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var departments = _context.Departments.Where(d => d.IsDeleted == true).ToList();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (department != null)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                department.IsDeleted = false;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            var updatedDepartment = _context.Departments.FirstOrDefault(d => d.Id == department.Id);
            updatedDepartment.DepartmentName = department.DepartmentName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var employees = _context.Employees.Include(e => e.Department).Where(e => e.Department.Id == id).ToList();
            var departmentName = _context.Departments.Where(d => d.Id == id).Select(x => x.DepartmentName).FirstOrDefault();
            ViewBag.department = departmentName;
            return View(employees);
        }
        public IActionResult SalesDetail(int id)
        {
            var sales = _context.Sales.Include(s => s.Employee).Include(p =>p.Product).Include(c => c.Customer).Where(e => e.Employee.Id == id).ToList();
            ViewBag.personelName = _context.Employees.Where(e => e.Id == id).Select(e => e.PersonnelName).FirstOrDefault();
            return View(sales);
        }
    }
}
