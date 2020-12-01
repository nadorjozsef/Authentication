using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "Bob@gmail.com")
            };

            var identity = new ClaimsIdentity(claims, "AuthAppIdentity");

            var userPrinciple = new ClaimsPrincipal(new[] { identity });

            HttpContext.SignInAsync(userPrinciple);

            return RedirectToAction("Index");
        }
    }
}
