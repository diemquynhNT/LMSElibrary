using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubjectService.Dto;
using SubjectService.Model;
using SubjectService.Service;

namespace SubjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiGiangController : ControllerBase
    {
        private readonly ISubjectService isp;

        public BaiGiangController(ISubjectService _isp)
        {
            isp = _isp;
        }
        [HttpGet("GetDocument")]
        public List<Lectures> GetDocument(string idtopic)
        {
            return isp.GetLectures(idtopic);
        }

        [HttpPost("AddLetures")]
        public async Task<ActionResult> AddLetures([FromForm] LeturesDTO leturesDTO, [FromForm] List<IFormFile> postedFile, string id)
        {

            try
            {
                string idles= await isp.AddLecture(leturesDTO.TitleLecture, id,leturesDTO.Mota);
                isp.AddVideo(leturesDTO.ResourcesUpload, idles);
                foreach (IFormFile t in postedFile)
                {
                    await isp.AddFile(t, idles);
                }
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpPost("EditDocument")]
        //public async Task<ActionResult> EditDocument([FromForm] string name, string id, string idtopic)
        //{


        //    try
        //    {
        //        await isp.EditDocument(name, id, idtopic);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpDelete("delete")]
        public IActionResult DeleteDoc(string id, string idtopic)
        {
            try
            {
                isp.DeleteLecture(id, idtopic);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
