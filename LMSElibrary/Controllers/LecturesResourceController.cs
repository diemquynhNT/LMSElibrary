using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SubjectService.Dto;
using SubjectService.Model;
using SubjectService.Service;
using System.IO;

namespace SubjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturesResourceController : ControllerBase
    {
        private readonly ISubjectService _context;
        public IWebHostEnvironment Environment { get; private set; }
        private readonly IMapper _mapper;

        public LecturesResourceController(ISubjectService context, IWebHostEnvironment _environment, IMapper mapper)
        {
            _context = context;
            Environment = _environment;
            _mapper = mapper;
        }

        [HttpGet("ListResource")]
        public List<Resources> ListResource()
        {
            var list = _context.GetAllResources();
            return list;
        }
        [HttpGet("ListLectures")]
        public List<Lectures> ListLectures(string id)
        {
            var list = _context.GetLectures(id);
            return list;
        }
        [HttpGet("video")]
        public async Task<IActionResult> GetVideoTest(string idRes)
        {
            var res = await _context.DetailResource(idRes);
            if (res == null)
                return BadRequest("khong tim thay res");
            string videoFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", res.FileURL);

            if (!System.IO.File.Exists(videoFilePath))
                return NotFound("khong tim thay video");

            return File(videoFilePath, "video/mp4");
        }
        //[HttpGet("GetResourceByName")]
        //public async Task<IActionResult> GetResourceByName(string name)
        //{
        //    var res = _context.GetResourceByName(name);
        //    if (res == null)
        //        return BadRequest();
        //    return Ok(res);

        //}

        [HttpGet("GetResourceByIdLectures")]
        public async Task<IActionResult> GetResourceByIdLectures(string idLectures)
        {
            var res = _context.GetResourcesForIdLectures(idLectures);
            if (res == null)
                return BadRequest();
            return Ok(res);

        }

        [HttpPost("AddLectureVideo")]
        public async Task<ActionResult> AddLectures([FromForm] LecturesModel lecturesModel,IFormFile videofile)
        {
            try
            {
                var lec = _mapper.Map<Lectures>(lecturesModel);
                string idLec=await _context.AddLecture(lec);
                _context.AddLecturesVideo(videofile, idLec);
                return Ok("thanh cong");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("AddFileResource")]
        public async Task<IActionResult> AddFileResource(string idLecture,List<IFormFile> postedFiles)
        {

            if (postedFiles.Count == 0)
            {
                return BadRequest();
            }
            try
            {
                foreach (IFormFile postedFile in postedFiles)
                {
                    await _context.AddFileResource(postedFile, idLecture);
                }
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost("AddLectureVideoAndResource")]
        public async Task<ActionResult> AddLectureVideoAndResource([FromForm] LecturesModel lecturesModel, IFormFile videofile,
            List<IFormFile> files,string idClass)
        {
            try
            {
                var lec = _mapper.Map<Lectures>(lecturesModel);
                string idLec = await _context.AddLecture(lec);
                _context.AddLecturesVideo(videofile, idLec);
                foreach (IFormFile postedFile in files)
                {
                    await _context.AddFileResource(postedFile, idLec);
                }
                //all lớp
                _context.PhanCongTL(idClass, idLec);

                return Ok("thanh cong");
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
        public IActionResult DeleteVideo(string id)
        {
            try
            {
                _context.DeleteResource(id);
                return Ok();


            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        
        



    }
}
