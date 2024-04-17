using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookClubApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            // Производим аутентификацию пользователя по его имени
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var identity = new ClaimsIdentity(claims, "UserName");
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Home");
        }
    }
}
