using ExamService.Data;
using ExamService.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;

namespace ExamService.Services
{
    public class ExamServices : IExamServices
    {
        private readonly MyDbExamContext _context;
        private readonly HttpClient _httpClient;

        public ExamServices(MyDbExamContext context, HttpClient httpClient)
        {
            this._context = context;
            _httpClient = httpClient;
        }
        public string AddExam(string idteacher, string status, Exams exams)
        {
            Random rd = new Random();
            exams.IdExam = "DT" + rd.Next(1, 9) + rd.Next(2, 99);
            exams.IdTeacher = idteacher;
            exams.StatusExam = status;
            //true trắc nghiệm
            if (exams.FormatExam = true)
                exams.FormatFile = ".xlxs";
            exams.FormatFile = ".docx";
            exams.DateExam = DateTime.Now;
            _context.Add(exams);
            _context.SaveChanges();
            return exams.IdExam;


        }

        public void AddExamByFile()
        {
            throw new NotImplementedException();
        }

        public void AddExamQuestion(string idexa, string ques)
        {
            DetailExam detail = new DetailExam();
            detail.IdExam = idexa;
            detail.IdQuestion = ques;
            _context.Add(detail);
            _context.SaveChanges();


        }

        public void AddQuestionsLibrabry(string id)
        {
            throw new NotImplementedException();
        }

        public string AddQuestions(string id, string idMon, Questions questions)
        {
            Random rd = new Random();
            questions.IdQuestion = "MCH" + rd.Next(1, 9) + rd.Next(2, 99);
            if (questions.LevelQuestion == null)
                questions.LevelQuestion = "Bình thường";
            questions.DateCreate = DateTime.Now;
            questions.IdUser = id;
            questions.IdMon = idMon;
            _context.Add(questions);
            _context.SaveChanges();
            return questions.IdQuestion;
        }


        public void AddOptions(string idQues, string content)
        {
            Random rd = new Random();
            OptionQuestion op = new OptionQuestion();
            op.IdQuestion = idQues;
            op.IdOptions = "MLC" + rd.Next(1, 9) + rd.Next(2, 99);
            op.ContentOption = content;
            _context.Add(op);
            _context.SaveChanges();
        }

        public void AddQuestuonsByFileExcel()
        {
            throw new NotImplementedException();
        }

        public void DeleteExam(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(string id)
        {
            throw new NotImplementedException();
        }

        public Task DownloadEXamById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Exams> EditNameExam(string id)
        {
            throw new NotImplementedException();
        }

        public void EditQuestion(string id)
        {
            throw new NotImplementedException();
        }

        public List<Exams> GetExams()
        {
            return _context.exams.ToList();
        }

        public Task<Exams> GetExamsById(string id)
        {
            return _context.exams.Where(t => t.IdExam == id).FirstOrDefaultAsync();
        }
        public List<DetailExam> GetQuestion(string id)
        {
           return _context.detailExams.Where(t => t.IdExam == id).ToList();
        }

        public Questions GetDetailQuestions(string id)
        {
            return _context.questions.Where(t => t.IdQuestion == id).FirstOrDefault();
        }

        public async Task<List<OptionQuestion>> GetOptionsQuestion(string id)
        {
            return _context.optionQuestions.Where(t => t.IdQuestion == id).ToList();
        }
        public async Task<bool> VerifySubjectExists(string idsubject)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7121/api/Subjects/SearchSubject?keyword={idsubject}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
                //if (response.StatusCode == HttpStatusCode.NotFound)
                //{
                //    return false;
                //}
                //else
                //{
                //    throw new Exception("Failed to verify subject existence from subject service.");
                //}
            }
        }

    }
}

