using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace user.Controllers
{
    public class SignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Assign()
        {
            return View();
        }
        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction("Assign");
        }
    }
}
