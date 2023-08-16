using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<BaiGiang> GetDocument(string Id)
        {
            return isp.GetDocment(Id);
        }

        [HttpPost("AddDocument")]
        public async Task<ActionResult> AddDocument([FromForm] string title, string id)
        {

            try
            {
                await isp.AddDocument(title, id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("EditDocument")]
        public async Task<ActionResult> EditDocument([FromForm] string name, string id, string idtopic)
        {


            try
            {
                await isp.EditDocument(name, id, idtopic);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteDoc(string id, string idtopic)
        {
            try
            {
                isp.DeleteDocument(id, idtopic);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
