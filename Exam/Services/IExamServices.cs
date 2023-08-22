using DocumentFormat.OpenXml.Packaging;
using ExamService.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ExamService.Services
{
    public interface IExamServices
    {
        

        public List<Exams> GetExams();
        public List<Questions> GetAllQuestion();
        public List<DetailExam> GetQuestion(string id);
        public Task<Exams> GetExamsById(string id);
        public Task<Exams> EditNameExam(string id);
        public Task<bool> DeleteExam(string id);
        public Task<bool> DeletExamAndQuestions(string idex,string idQues);
        public string AddExam(string idteacher,string status,Exams exams);
        public Task<bool>VerifySubjectExists(string idsubject);

        public Task DownloadEXamById(string id);
        public void AddExamByFile();
        //thu vine de
        public string AddQuestions(string id, string idMon, Questions questions);
        public void AddExamQuestion(string idexa, string ques);

        //thêm question bằng excel
        public Task<List<Questions>> ImportDocument(IFormFile file);
        public Task<Questions> GetDetailQuestions(string id);
        public Task<Questions> UpdateQuestion(Questions objQues);
        public Task<bool> DeleteQuestion(string id);
       

        







    }
}
