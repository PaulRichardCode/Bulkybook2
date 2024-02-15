using Bulkybook2.Models;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Bulkybook2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

           //// RedirectToAction("List", "Category");
            return View();
        }

        public IActionResult List()
        {
            var student = dbContext.Categories.ToList();
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var names = dbContext.Categories.Find(id);

            if (names == null)
            {
                return NotFound();
                
            }
            return View(names);
        }
    }
}
