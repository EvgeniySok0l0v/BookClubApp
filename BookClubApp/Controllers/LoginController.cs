using BookClubApp.Entity;
using BookClubApp.Models;
using BookClubApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookClubApp.Controllers
{
    /// <summary>
    /// LoginController class
    /// </summary>
    /// <param name="userService"></param>
    public class LoginController(IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService; 
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login method, if user not found user will create
        /// </summary>
        /// <param name="model">login model</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetUserByUserName(userName: model.UserName);
                if (user != null)
                {
                    await Authenticate(userName: model.UserName); 

                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    _userService.CreateUser(new User(model.UserName));
                    await Login(model);
                    return RedirectToAction("Index", "Book");
                }
            }

            return View(model);
        }

        /// <summary>
        /// Authenticate method 
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns></returns>
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        /// <summary>
        /// Logout method
        /// </summary>
        /// <returns>redirect to Login</returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
