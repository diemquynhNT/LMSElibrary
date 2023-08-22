using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Dto;
using UserService.Model;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IUsers iuser;
        private readonly IMapper _mapper;

        public PositionsController(IUsers _iuser,IMapper mapper)
        {
            iuser = _iuser;
            _mapper = mapper;

        }

        [HttpGet("ListPostion")]
        public Task<IEnumerable<Position>> GetAllUsers()
        {
            var listpos = iuser.GetAllPost();
            return listpos;
        }


        [HttpGet("GetPosById")]
        public async Task<ActionResult> GetPosByiD(string Id)
        {
            try
            {
                var p = await iuser.GetPosById(Id);
                if (p == null)
                    return BadRequest("khong tim thay");
                return Ok(p);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("AddPosition")]
        public async Task<ActionResult> AddPosition([FromForm] PositionModel posDetails)
        {
            if (posDetails == null)
            {
                return BadRequest();
            }
            try
            {
                var pos=_mapper.Map<Position>(posDetails);
                await iuser.AddPos(pos);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("editPos")]
        public async Task<IActionResult> editPos([FromForm] PositionModel p)
        {
            var pos = await iuser.GetPosById(p.IdPos);
            if (pos == null)
                return NotFound("Khong tim thay");
            _mapper.Map(p, pos);
            await iuser.EditPos(pos);
            return Ok("thanh cong");
        }


        [HttpDelete("deletePos")]
        public async Task<IActionResult> deletePos(string id)
        {
             iuser.DeletePos(id);
            return Ok("xoa thanh cong");
        }

    }
}
