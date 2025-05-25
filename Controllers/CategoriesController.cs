using Microsoft.AspNetCore.Mvc;

namespace SDF1App.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
