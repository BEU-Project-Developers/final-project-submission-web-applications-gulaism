using KodlaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KodlaWebApp.Controllers
{
    public class AccountController : Controller
    {
        private static List<string> RegisteredEmails = new List<string>
        {
            "test@example.com", // fake existing users
            "user@domain.com"
        }; // db simulation

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel model)
        {
            if (RegisteredEmails.Contains(model.Email))
            {
                ModelState.AddModelError("Email", "This email is already registered! 😤");
            }

            if (ModelState.IsValid)
            {
                TempData["Success"] = "Registration successful!";
                return RedirectToAction("SignUp");
            }

            return View(model);
        }

        public IActionResult SignUp() => View();
        public IActionResult ForgetPas() => View();

    }

}
