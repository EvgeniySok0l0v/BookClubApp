using BookClubApp.Entity;
using BookClubApp.Models;
using BookClubApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookClubApp.Controllers
{
    public class LoginController(ApplicationDbContext? context, IUserService userService) : Controller
    {
        private readonly ApplicationDbContext? _context = context;
        private readonly IUserService _userService = userService; 
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetUserByUserName(userName: model.UserName);
                if (user != null)
                {
                    await Authenticate(userName: model.UserName); // аутентификация

                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    _context.Users.Add(new User(model.UserName));
                    _context.SaveChanges();
                    await Login(model);
                    return RedirectToAction("Index", "Book");
                }
                //ModelState.AddModelError("", "Некорректные логин");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
