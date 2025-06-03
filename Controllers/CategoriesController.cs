using Microsoft.AspNetCore.Mvc;

namespace KodlaWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
