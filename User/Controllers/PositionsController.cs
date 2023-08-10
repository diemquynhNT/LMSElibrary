using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Model;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IUsers iuser;

        public PositionsController(IUsers _iuser)
        {
            iuser = _iuser;
           
        }

        [HttpGet("ListPostion")]
        public Task<IEnumerable<Position>> GetAllUsers()
        {
            var listpos = iuser.GetAllPost();
            return listpos;
        }


        [HttpGet("GetPosById")]
        public Task<Position> GetPosByiD(string Id)
        {
            var p = iuser.GetPosById(Id);
            return p;
        }

        [HttpPost("AddPosition")]
        public async Task<ActionResult> AddUser([FromForm] PositionModel posDetails)
        {
            if (posDetails == null)
            {
                return BadRequest();
            }

            try
            {
              
                await iuser.AddPos(posDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
