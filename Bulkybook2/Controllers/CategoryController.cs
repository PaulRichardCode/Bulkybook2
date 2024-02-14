using Microsoft.AspNetCore.Mvc;

namespace Bulkybook2.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
