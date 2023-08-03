using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectService.Model;
using SubjectService.Service;

namespace SubjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService isp;

        public SubjectsController(ISubjectService _isp)
        {
            isp = _isp;
        }

        [HttpGet("list")]
        public Task<IEnumerable<Subject>> SubjectListAsync()
        {
                var subjectList = isp.GetSubjectListAsync();
                return subjectList;
        }
        [HttpGet("filterlist")]
        public Task<Subject> GetSubjectByIdAsync(string Id)
        {
            return isp.GetSubjectByIdAsync(Id);
        }


    }
}
