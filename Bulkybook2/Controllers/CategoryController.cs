using Bulkybook2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return RedirectToAction("List", "Category");
            
        }

        public IActionResult List()
        {
            var student = dbContext.Categories.ToList();
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
                
            }
            var names = dbContext.Categories.Find(id);

            if (names == null)
            {
                return NotFound();
            }
            return View(names);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot match the name");
            }
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(obj);
                dbContext.SaveChanges();
                return RedirectToAction("List");
            }
           

            // Redirect to the action "List"
            return View(obj);

        }

       public IActionResult Delete(int id)
        {
            var dele = dbContext.Categories.Find(id);
            if(dele == null)
            {
                return NotFound();  
            }
            dbContext.Categories.Remove(dele);
            dbContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
