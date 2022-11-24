using Microsoft.AspNetCore.Mvc;
using Project.UserService;
using user.Models;

namespace user.Controllers
{
    public class RegisterController : Controller
    {

        private readonly Iuser user;

        public RegisterController(Iuser user)
        {
            this.user = user;
        }

        public IActionResult Sign()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User data)
        {

            user.Create(data);
            return RedirectToAction("Sign");
        }
    }
}
