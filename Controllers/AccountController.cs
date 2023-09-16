using GSL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GSL.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                // Use Firebase SDK to register the user and save other details in Firestore
            }
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Use Firebase SDK to authenticate the user
            }
            return RedirectToAction("Index", "Home");
        }

    }
}