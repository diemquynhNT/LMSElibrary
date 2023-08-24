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
    public class QuestionsController : ControllerBase
    {
        private readonly ISubjectService _context;
        private readonly IMapper _mapper;

        public QuestionsController(ISubjectService context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("ListAllQuestion")]
        public List<Questions> ListAllSubject(string idLectures)
        {
            return _context.GetAllQuestionForLectures(idLectures);
           
        }
        [HttpPost("AddQuestions")]
        public async Task<ActionResult> AddLectures(List<string> idClass, string idUser ,[FromForm] QuestionModel questionModel)
        {
            try
            {
                var questions = _mapper.Map<Questions>(questionModel);
                foreach(var item in idClass)
                {
                    await _context.AddQuestions(questions, item, idUser);
                }
               
                return Ok("thanh cong");
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
