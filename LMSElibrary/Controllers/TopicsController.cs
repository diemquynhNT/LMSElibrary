using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectService.Model;
using SubjectService.Service;

namespace SubjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ISubjectService isp;

        public TopicsController(ISubjectService _isp)
        {
            isp = _isp;
        }
        [HttpGet("ListTopic")]
        public List<Topic> GetTopic(string IdSubject)
        {
            return isp.GetTopicsSubject(IdSubject);
        }
        [HttpGet("DetailTopic")]
        public List<Lectures> GetDetailTopic(string idTopic)
        {
            return isp.GetLectures(idTopic);
        }

        [HttpPost("AddTopic")]
        public async Task<ActionResult> AddTopic([FromForm] string idSubject, [FromForm] string title)
        {

            try
            {
                await isp.AddTopic(title, idSubject);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("EditTopic")]
        public async Task<ActionResult> EditTopic(string idTopic, [FromForm] string title)
        {


            try
            {
                await isp.EditTopic(title,idTopic);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteTopic(string id, string idtopic)
        {
            try
            {
                var check= await isp.DeleteTopic(idtopic);
                if (!check)
                    return BadRequest();
                return Ok();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
