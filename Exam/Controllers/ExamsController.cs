using AutoMapper;
using AutoMapper.Features;
using ExamService.Dto;
using ExamService.Model;
using ExamService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamServices _context;
        private readonly IMapper _mapper;

        public ExamsController(IExamServices icontext, IMapper mapper)
        {
            _context = icontext;
            _mapper = mapper;
        }
        [HttpGet("GetListExam")]
        public List<Exams> GetListExam()
        {
            return _context.GetExams();
        }
        [HttpGet]
        public async Task<bool> CheckSubjectExistsFromExamService(string subjectId)
        {
            var subjectExists = await _context.VerifySubjectExists(subjectId);
            return subjectExists;
        }

        [HttpPost("AddExam")]
        public async Task<ActionResult> AddExam(string idteacher,string starus,[FromForm]ExamModel examModel, [FromForm] QuestionsModel questionsModel)
        {

            try
            {
                var subjectExists = await _context.VerifySubjectExists(examModel.IdSubject);
                if (subjectExists == true)
                {
                    Exams ex = _mapper.Map<Exams>(examModel);
                    var ques = _mapper.Map<Questions>(questionsModel);
                    string exams = _context.AddExam(idteacher, starus, ex);
                    string questions = _context.AddQuestions(idteacher, exams, ques);
                    _context.AddExamQuestion(exams, questions);
                    if (ex.FormatExam = true)
                    {
                        foreach (var t in questionsModel.Ques)
                        {
                            _context.AddOptions(questions, t.content);
                        }
                    }
                    return Ok("them thanh cong");
                }
                return BadRequest("khong tim thay subject");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
