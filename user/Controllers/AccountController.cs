using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.UserService;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using user.Models;

namespace user.Controllers
{

    public class AccountController : Controller
    {

        public readonly Iuser iuser;

        public AccountController(Iuser iuser)
        {
            this.iuser = iuser;
        }

        [AllowAnonymous]
        public IActionResult Login(string str)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                var result = iuser.ByRoll("Spget", user);

                if (result>0)
                {
                    var Identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(Identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Assign", "Sign");
                }
                else
                {
                    return Redirect("Login");
                }
            }
            catch
            {
                return Redirect("Login");

            }
        }
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("login");
        }
    }
}
