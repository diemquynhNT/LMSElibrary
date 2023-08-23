using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectService.Data;
using SubjectService.Model;
using SubjectService.Service;

namespace SubjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _context;

        public SubjectsController(ISubjectService context)
        {
            _context = context;
        }

        [HttpGet("ListAllSubject")]
        public List<Subject> ListAllSubject()
        {
            var subjectList = _context.GetAllSubject();
            return subjectList;
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

      

        //[HttpGet("DetailSubject")]
        //public Task<Subject> GetSubjectByIdAsync(string Id)
        //{
        //    return isp.GetSubjectByIdAsync(Id);
        //}






        //[HttpGet("SearchSubject")]
        //public async Task<ActionResult<Subject>> SearchSubject(string keyword)
        //{
        //    try
        //    {
        //        var sub = await isp.GetSubjectByIdAsync(keyword);
        //        if (sub != null)
        //        {
        //            return sub;
        //        }
        //        return BadRequest("Lỗi");
        //    }
        //    catch
        //    {
        //        return BadRequest("Lỗi");
        //    }
        //}



    }
}
