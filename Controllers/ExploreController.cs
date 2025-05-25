using Microsoft.AspNetCore.Mvc;

namespace SDF1App.Controllers
{
    public class ExploreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
