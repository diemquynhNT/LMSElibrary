using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SubjectService.Model;
using SubjectService.Service;

namespace SubjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ISubjectService _context;
        public IWebHostEnvironment Environment { get; private set; }

        public ResourceController(ISubjectService context, IWebHostEnvironment _environment)
        {
            _context = context;
            Environment = _environment;
        }
        [HttpPost("AddResource")]
        public async Task<ActionResult> AddUser([FromForm] TaiLieuModel res, string id)
        {
            if (res == null)
            {
                return BadRequest();
            }

            try
            {
                await _context.AddVideo(res.ResourcesUpload, id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetVideo")]
        public List<Resources> GetVideo()
        {
            return _context.GetVideo();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteTopic(string id)
        {
            try
            {
                _context.DeleteVideo(id);
                return Ok();


            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        //[RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public IActionResult Index(List<IFormFile> postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                   
                    postedFile.CopyTo(stream);
                }
            }
            return Ok();
        }

        

    }
}
