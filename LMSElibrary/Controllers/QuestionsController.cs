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
        public List<QuestionsVM> ListAllQuestion(string idLectures, string idClass)
        {
            var list= _context.GetAllQuestionForLectures(idLectures, idClass);
            List<QuestionsVM> listVM = new List<QuestionsVM>();
            foreach(var question in list)
            {
                var ques = _mapper.Map<QuestionsVM>(question);
                listVM.Add(ques);
            }
            return listVM;
           
        }
        [HttpPost("AddQuestions")]
        public async Task<ActionResult> AddQuestions(string idLectures,string idUser ,[FromForm] QuestionModel questionModel)
        {
            try
            {
                var questions = _mapper.Map<Questions>(questionModel);
               await _context.AddQuestions(questions, questionModel.idClass, idUser,idLectures);
                
               
                return Ok("thanh cong");
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
