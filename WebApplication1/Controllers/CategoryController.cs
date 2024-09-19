using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly TicariContext _context;
        public CategoryController(TicariContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
           return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();  
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            var updatedCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            updatedCategory.CategoryName = category.CategoryName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
