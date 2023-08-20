using ExamService.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ExamService.Services
{
    public interface IExamServices
    {
        public List<Exams> GetExams();
        public Task<Exams> GetExamsById(string id);
        public Task<Exams> EditNameExam(string id);
        public void DeleteExam(string id);
        public string AddExam(string idteacher,string status,Exams exams);
        public Task<bool>VerifySubjectExists(string idsubject);

        public Task DownloadEXamById(string id);
        public void AddExamByFile();
        //thu vine de
        public string AddQuestions(string id, string idMon, Questions questions);

        //thêm từ file
        public void AddQuestionsLibrabry(string id);

        public void AddExamQuestion(string idexa, string ques);
        public void AddOptions(string idQues,string content);

       


        public void AddQuestuonsByFileExcel();
        public void GetDeailQuestion(string id);
        public void EditQuestion(string id);
        public void DeleteQuestion(string id);








    }
}
