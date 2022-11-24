using Microsoft.AspNetCore.Mvc;
using Project.UserService;
using System.Drawing;
using user.UserServices;

namespace user.Controllers
{
    public class RecordController : Controller
    {
        private readonly Iuser user;

        public RecordController(Iuser user)
        {
            this.user = user;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Get(string Phonenumber)
        {
            var data = user.GetAsignment("sp_uploadget",Phonenumber);
            return View(data);
        }

    }
}
