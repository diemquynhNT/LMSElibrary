using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectService.Dto;
using SubjectService.Model;
using SubjectService.Service;

namespace SubjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ISubjectService _context;
        private readonly IMapper _mapper;

        public ClassController(ISubjectService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("ListAllClass")]
        public List<ClassSubject> ListAllClass()
        {
            var list= _context.GetAllClass();
            return list;
            
        }

        [HttpGet("ListAllPC")]
        public List<ClassAssignment> ListAllPC()
        {
            var list = _context.GetAllPC();
            return list;

        }

        //[HttpGet("GetDetailSubject")]
        //public async Task<ActionResult> GetSubjectByIdAsync(string Id)
        //{
        //    var sub = _context.GetSubjectByIdAsync(Id);
        //    if (sub == null)
        //        return BadRequest();
        //    return Ok(sub);
        //}

        [HttpPost("AddClass")]
        public async Task<ActionResult> AddClass([FromForm] ClassModel classModel)
        {

            try
            {
                var l = _mapper.Map<ClassSubject>(classModel);
                await _context.AddClass(l);
                return Ok("da tao class");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("UpdateClass")]
        public async Task<IActionResult> UpdateClass(string id, [FromBody] ClassModel classModel)
        {
            var l = await _context.GetClass(id);
            if (l == null)
            {
                return NotFound("Khong tim thay ");
            }
            _mapper.Map(classModel, l);
            await _context.EditClass(l);
            return Ok("thanh cong");
        }
        [HttpDelete("DeleteClass")]
        public async Task<IActionResult> DeleteClass(string id)
        {
            var result = await _context.DeleteClass(id);
            if (!result)
                return NotFound();
            return Ok("xoa thanh cong");
        }

    }
}
