using Microsoft.AspNetCore.Mvc;

namespace user.Models
{
    public class Upload
    {
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public string Image { get; set; }
        public IFormFile Imagename { get; set; }

    }
}
