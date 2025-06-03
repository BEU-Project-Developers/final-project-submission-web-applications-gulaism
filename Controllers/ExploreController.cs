using Microsoft.AspNetCore.Mvc;

namespace KodlaWebApp.Controllers
{
    public class ExploreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
