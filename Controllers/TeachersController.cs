using Microsoft.AspNetCore.Mvc;

namespace SDF1App.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
