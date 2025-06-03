using Microsoft.AspNetCore.Mvc;

namespace KodlaWebApp.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
