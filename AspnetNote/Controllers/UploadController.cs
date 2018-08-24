using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetNote.Controllers
{
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost, Route("api/upload")]
        public IActionResult ImageUpload(IFormFile file)
        {
            // image or file upload
            // Path where save 
            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
            // Name - DateTime,GUID
            // Extension(jpg, png
            var fileName = file.FileName;

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }


            return Ok(new { file = "/images/upload" + fileName, success = true });
        }
    }
}