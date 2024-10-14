using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly TicariContext _context;
        public ProductController(TicariContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            //Dropdown liste ile kategori seçimi için ViewBag kullanılmıştır.
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryName", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            //Formdan gelen category ismi ile categori bulunmuş ve veri tabanına o şekilde eklenmiştir.
            var category = _context.Categories.FirstOrDefault(c => c.CategoryName == product.Category.CategoryName);

            product.Category = category;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var product = _context.Products.FirstOrDefault(c => c.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
