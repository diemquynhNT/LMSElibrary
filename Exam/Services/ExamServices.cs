using DocumentFormat.OpenXml.Office2010.Excel;
using ExamService.Data;
using ExamService.Model;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
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

     
        public string AddQuestions(string idTeacher, string idMon, Questions questions)
        {
            Random rd = new Random();
            questions.IdQuestion = "MCH" + rd.Next(1, 9) + rd.Next(2, 99);
            if (questions.LevelQuestion == null)
                questions.LevelQuestion = "Bình thường";
            questions.DateCreate = DateTime.Now;
            questions.IdUser = idTeacher;
            questions.IdMon = idMon;
            _context.Add(questions);
            _context.SaveChanges();
            return questions.IdQuestion;
        }



        public async Task<bool> DeleteExam(string id)
        {
            var exam = await _context.exams.FindAsync(id);
            if (exam == null)
                return false;

            _context.exams.Remove(exam);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteQuestion(string id)
        {
            var ques = await _context.questions.FindAsync(id);
            if (ques == null)
                return false;

            _context.questions.Remove(ques);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletExamAndQuestions(string idex, string idQues)
        {
            var t = await _context.detailExams.FindAsync(idex, idQues);
            if (t == null)
                return false;

            _context.detailExams.Remove(t);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task DownloadEXamById(string id)
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

        public Task<Questions> GetDetailQuestions(string id)
        {
            return _context.questions.Where(t => t.IdQuestion == id).FirstOrDefaultAsync();
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
            }
        }


        public List<Questions> GetAllQuestion()
        {
            return _context.questions.ToList();
        }
        public async Task<Questions> UpdateQuestion(Questions objQues)
        {
            _context.questions.Update(objQues);
            await _context.SaveChangesAsync();
            return objQues;
        }

            public async Task<List<Questions>> ImportDocument(IFormFile file)
        {
            var list = new List<Questions>();
           
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage())
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    package.Load(stream);
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {
                        list.Add(new Questions
                        {
                            STT = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                            IdQuestion = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            ContentQuestion = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            LevelQuestion = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            ChoiceA = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            ChoiceB = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            ChoiceC = worksheet.Cells[row, 7].Value.ToString().Trim(),
                            ChoiceD = worksheet.Cells[row, 8].Value.ToString().Trim(),
                            AnswerQuestions = worksheet.Cells[row, 9].Value.ToString().Trim(),
                            DateCreate = DateTime.Now
                        });

                    }
                }
                return list;
            }
        }

        public Task<Exams> EditNameExam(string id)
        {
            throw new NotImplementedException();
        }


        //public void ImportDocument(IFormFile file)
        //{
        //    List<Questions> questionsList = new List<Questions>();

        //    using (var excelPackage = new ExcelPackage(file.OpenReadStream()))
        //    {
        //        var worksheet = excelPackage.Workbook.Worksheets[0]; // Lấy sheet đầu tiên

        //        int rowCount = worksheet.Dimension.Rows;
        //        int colCount = worksheet.Dimension.Columns;

        //        for (int row = 2; row <= rowCount; row++) // Bắt đầu từ hàng 2 để bỏ qua header
        //        {
        //            var question = new Questions();

        //            question.STT = Convert.ToInt32(worksheet.Cells[row, 1].Value);
        //            question.IdQuestion = worksheet.Cells[row, 2].Value.ToString().Trim();
        //            question.ContentQuestion = worksheet.Cells[row, 3].Value.ToString().Trim();
        //            question.LevelQuestion = worksheet.Cells[row, 4].Value.ToString().Trim();
        //            question.ChoiceA = worksheet.Cells[row, 5].Value.ToString().Trim();
        //            question.ChoiceB = worksheet.Cells[row, 6].Value.ToString().Trim();
        //            question.ChoiceC = worksheet.Cells[row, 7].Value.ToString().Trim();
        //            question.ChoiceD = worksheet.Cells[row, 8].Value.ToString().Trim();
        //            question.AnswerQuestions = worksheet.Cells[row, 9].Value.ToString().Trim();
        //            question.IdMon = "haha";
        //            question.IdUser = "demo";
        //            question.DateCreate = DateTime.Now;
        //            questionsList.Add(question);
        //        }
        //    }

        //}

    }
}

