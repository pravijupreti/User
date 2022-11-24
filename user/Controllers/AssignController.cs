using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Reflection;
using user.Models;
using user.UserServices;

namespace user.Controllers
{
    public class AssignController : Controller
    {
        private readonly Iup upload;
        public AssignController(Iup upload)
        {
            this.upload = upload;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Post(Upload add)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Post(Upload add, IFormFile Imagename)
        {
            string imgname = Imagename.FileName;
            imgname = Path.GetFileName(imgname);
            string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", imgname);
            var stream = new FileStream(uploadpath, FileMode.Create);
            Imagename.CopyToAsync(stream);
            upload.UP("sp_assignment", add,uploadpath);
            return RedirectToAction("Post");
        }
    }
}
