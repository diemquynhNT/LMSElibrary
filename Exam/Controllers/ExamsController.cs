using AutoMapper;
using AutoMapper.Features;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using ExamService.Dto;
using ExamService.Model;
using ExamService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text;

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
        [HttpGet("GetListQuestion")]
        public List<Questions> GetListQuestion()
        {
            return _context.GetAllQuestion();
        }

        [HttpGet("GetListQuestionById")]
        public async Task<ActionResult> GetListQuestionById(string idexam)
        {
            try
            {
                var list = _context.GetQuestion(idexam);
                if (list != null)
                    return Ok(list);
                return BadRequest("Không tìm thấy");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }
        [HttpGet]
        public async Task<bool> CheckSubjectExistsFromExamService(string subjectId)
        {
            var subjectExists = await _context.VerifySubjectExists(subjectId);
            return subjectExists;
        }
        //[HttpPost]
        //public async Task<ActionResult> AddQuestion(string id,string idmon, [FromForm] QuestionsModel questionsModel, [FromForm] List<string> op)
        //{
        //   var ques = _mapper.Map<Questions>(questionsModel);
        //    return Ok("them thanh cong");

        //}

        [HttpPost("AddExam")]
        public async Task<ActionResult> AddExam(string idteacher,string starus,[FromForm]ExamModel examModel)
        {

            try
            {
              var subjectExists = await _context.VerifySubjectExists(examModel.IdSubject);
               
                if (subjectExists == true)
                {
                    var ex = _mapper.Map<Exams>(examModel);

                    string exams = _context.AddExam(idteacher, starus, ex);
                    
                    return Ok();
                }
                return BadRequest("khong tim thay subject");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("AddQuestionToExam")]
        public async Task<ActionResult> AddQuestion(string idmon,string idexam,string idTecher,List<QuestionsModel> questionsModel)
        {
            try
            {
                var ex = _context.GetExamsById(idexam);
                if(ex == null)
                    return BadRequest("khong tim thay exam");

                foreach (var item in questionsModel)
                {
                    var ques = _mapper.Map<Questions>(item);
                    var idques = _context.AddQuestions(idTecher, idmon, ques);
                    _context.AddExamQuestion(idexam, idques);

                }
                return Ok();
                
                
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpPost("ImportDocument")]
        public async Task<IActionResult> ImportDocumentAsync(IFormFile file,string id,string iusser)
        {
            if (file != null && file.Length > 0)
            {
                Task<List<Questions>> task = _context.ImportDocument(file);
                List<Questions> questionList = await task;

                foreach (var item in questionList)
                {
                    _context.AddQuestions(iusser, id, item);
                }

                return Ok();
            }

            
            return BadRequest();
        }

        [HttpDelete("deleteExam")]
        public async Task<IActionResult> DeleteExam(string id)
        {
            var result = await _context.DeleteExam(id);
            if (!result)
                return NotFound();
            return Ok("xoa thanh cong");
        }
        [HttpDelete("deleteQuestion")]
        public async Task<IActionResult> deleteQuestion(string id)
        {
            var result = await _context.DeleteQuestion(id);
            if (!result)
                return NotFound();
            return Ok("xoa question thanh cong");
        }




    }
}
