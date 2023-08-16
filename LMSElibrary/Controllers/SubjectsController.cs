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
        private readonly ISubjectService isp;

        public SubjectsController(ISubjectService _isp)
        {
            isp = _isp;
        }

        [HttpGet("list")]
        public List<MonHoc> SubjectListAsync()
        {
                var subjectList = isp.GetSubjectListAsync();
                return subjectList;
        }
        [HttpGet("GetById")]
        public Task<MonHoc> GetSubjectByIdAsync(string Id)
        {
            return isp.GetSubjectByIdAsync(Id);
        }


        [HttpGet("SearchSubject")]
        public Task<MonHoc> SearchSubject(string keyword)
        {
            var sub = isp.GetSubjectByIdAsync(keyword);
            if (sub == null)
                return isp.GetSubjectByName(keyword);
            return sub;
        }

    

    }
}
