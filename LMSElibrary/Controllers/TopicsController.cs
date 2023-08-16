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
        [HttpGet("GetTopic")]
        public List<Topic> GetTopic(string Id)
        {
            return isp.GetTopicsSubject(Id);
        }

        [HttpPost("AddTopic")]
        public async Task<ActionResult> AddTopic([FromForm] string name, [FromForm] string id)
        {

            try
            {
                await isp.AddTopic(name, id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("EditTopic")]
        public async Task<ActionResult> EditTopic([FromForm] string name, string id, string idtopic)
        {


            try
            {
                await isp.EditTopic(name, id, idtopic);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteTopic(string id, string idtopic)
        {
            try
            {
                isp.DeleteTopic(id,idtopic);
                return Ok();


            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
