using AutoMapper;
using AutoMapper.Features;
using ExamService.Dto;
using ExamService.Model;
using ExamService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
        public async Task<ActionResult> AddExam(string idteacher,string starus,[FromForm]ExamModel examModel, [FromForm] QuestionsModel questionsModel, 
            [FromForm] List<string> demo)
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
                        foreach (var t in demo)
                        {
                            _context.AddOptions(questions, t);
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

        [HttpGet("GetDetailExams")]
        public async Task<ActionResult> GetDetailExams(string keyword)
        {
            try
            {
                var sub = await _context.GetExamsById(keyword);
                if (sub != null)
                    return Ok(sub);
                return BadRequest("Không tìm thất");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        

        [HttpGet("GetQuestion")]
        public async Task<ActionResult> GetQuestion(string keyword)
        {
            try
            {
                var sub = _context.GetQuestion(keyword);
                if (sub == null)
                    return BadRequest("Không tìm thấy");

                List<Questions> detailList = new List<Questions>();
                foreach (var t in sub)
                {
                    var detail = _context.GetDetailQuestions(t.IdQuestion);
                    detailList.Add(detail);
                }

                if (detailList.Count > 0)
                    return Ok(detailList[0]);
                else
                    return BadRequest("khong co ds");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }





    }
}
