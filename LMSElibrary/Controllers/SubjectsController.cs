using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectService.Data;
using SubjectService.Dto;
using SubjectService.Model;
using SubjectService.Service;

namespace SubjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _context;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("ListAllSubject")]
        public List<Subject> ListAllSubject()
        {
            var subjectList = _context.GetAllSubject();
            return subjectList;
        }
        [HttpGet("ListAllDepartment")]
        public List<Department> ListAllDepartment()
        {
            var list = _context.GetAllDepartment();
            return list;
        }

        [HttpGet("ListSubjectForTeacher")]
        public List<Subject> ListSubjectForTeacher(string idTeacher)
        {
            var subjectList = _context.GetAllSubjectForTeacher(idTeacher);
            return subjectList;
        }


        [HttpGet("ListClassForTeacher")]
        public List<ClassSubject> ListClassForTeacher(string idTeacher,string idSubject)
        {
            var classList = _context.GetAllClassForTeacher(idTeacher,idSubject);
            return classList;
        }
        [HttpGet("GetDetailSubject")]
        public async Task<ActionResult> GetSubjectByIdAsync(string Id)
        {
            var sub = _context.GetSubjectByIdAsync(Id);
            if (sub == null)
                return BadRequest();
            return Ok(sub);
        }
        [HttpGet("SearchSubject")]
        public async Task<ActionResult<Subject>> SearchSubject(string keyword)
        {
            try
            {
                var sub = await _context.GetSubjectByIdAsync(keyword);
                if (sub != null)
                {
                    return sub;
                }
                return BadRequest("Lỗi");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }
        [HttpPost("AddSubject")]
        public async Task<ActionResult> AddSubject([FromForm] SubjectModel subjectModel)
        {

            try
            {
                
                var sub = _mapper.Map<Subject>(subjectModel);
                await _context.AddSubject(sub);
                return Ok("da tao subject");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(string id, [FromBody] SubjectModel subjectModel)
        {
            var sub = await _context.GetSubjectByIdAsync(id);
            if (sub == null)
            {
                return NotFound("Khong tim thay subject");
            }
            _mapper.Map(subjectModel, sub);
            await _context.UpdateSubject(sub);
            return Ok("thanh cong");
        }
        [HttpDelete("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(string id)
        {
            var result = await _context.DeleteSubject(id);
            if (!result)
                return NotFound();
            return Ok("xoa thanh cong");
        }




    }
}
