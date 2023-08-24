using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SubjectService.Data;
using SubjectService.Dto;
using SubjectService.Model;

namespace SubjectService.Service
{
    public class SubjecstService : ISubjectService
    {
        private readonly MyDbContext _dbContext;
        public static IWebHostEnvironment _webHostEnvironment;
        private object _context;

        public SubjecstService(MyDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;

        }

        public string RandomId(string keyword)
        {
            Random rd = new Random();
            var id = keyword + rd.Next(1, 9) + rd.Next(10, 99);
            return id;
        }
        //Subject
        #region
        public async Task<Subject> GetSubjectByIdAsync(string id)
        {
            return await _dbContext.subjects.Where(x => x.IdSubject == id).FirstOrDefaultAsync();
        }

        public async Task<Subject> GetSubjectByName(string id)
        {
            return await _dbContext.subjects.Where(x => x.NameSubject == id).FirstOrDefaultAsync();
        }

        public List<Subject> GetAllSubject()
        {
            return _dbContext.subjects.ToList();
        }
        public List<Department> GetAllDepartment()
        {
            return _dbContext.departments.ToList();
        }

        public List<Subject> GetAllSubjectForTeacher(string idTeacher)
        {
            List<DetailClass> list = _dbContext.detailClasses.Where(t => t.IdTeacher == idTeacher).ToList();
            List<Subject> result = new List<Subject>();
            foreach (var item in list)
            {
                var detail = _dbContext.subjects.FirstOrDefault(t => t.IdSubject == item.IdSubject);
                result.Add(detail);

            }
            return result;
        }

        public async Task<Subject> AddSubject(Subject subject)
        {
            subject.IdSubject = RandomId("MH");
            _dbContext.Add(subject);
            _dbContext.SaveChanges();
            return subject;
        }

        public async Task<Subject> UpdateSubject(Subject subject)
        {
            _dbContext.subjects.Update(subject);
            await _dbContext.SaveChangesAsync();
            return subject;
        }

        public async Task<bool> DeleteSubject(string id)
        {
            var l = _dbContext.classSubjects.SingleOrDefault(t => t.IdClass == id);
            if (l != null)
            {
                _dbContext.Remove(l);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        public List<Topic> GetTopicsSubject(string id)
        {
            return _dbContext.topics.Where(t => t.IdSubject == id).ToList();
        }

        public List<Resources> GetVideo()
        {
            return _dbContext.Resources.Where(t => t.FormatFile == "video/mp4").ToList();

        }

      
        public async Task AddTopic(string nametopic, string id)
        {
                Random rd = new Random();
                var tp = new Topic();
                tp.IdTopic=Guid.NewGuid().ToString();
                tp.TitleTopic = nametopic;
                tp.IdSubject=id;
                _dbContext.topics.Add(tp);
                await _dbContext.SaveChangesAsync();
            
        }

        public void DeleteLecture(string iddoc, string idtopic)
        {
            var doc = _dbContext.lectures.SingleOrDefault(t => t.IdTopic == idtopic && t.IdLecture == iddoc);
            if (doc != null)
            {
                _dbContext.Remove(doc);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteTopic(string id, string idtopic)
        {
            var topic = _dbContext.topics.SingleOrDefault(t => t.IdTopic == idtopic &&t.IdSubject==id);
            if (topic != null)
            {
                _dbContext.Remove(topic);
                _dbContext.SaveChanges();
            }
        }


        public async Task EditTopic(string nametopic, string id, string idtopic)
        {
           var tp=_dbContext.topics.Where(t=>t.IdTopic ==idtopic && t.IdSubject==id).FirstOrDefault();
            if(nametopic!=null)
            {
                tp.TitleTopic=nametopic;
                await _dbContext.SaveChangesAsync();

            }    
        }



        //Lectures
        #region
        public List<Lectures> GetLectures(string id)
        {
            return _dbContext.lectures.Where(t => t.IdTopic == id).ToList();
        }

        public async Task<string> AddLecture(Lectures lectures)
        {
           Random rd=new Random();
            lectures.IdLecture="BG"+rd.Next(1,9)+rd.Next(10,99);
            _dbContext.Add(lectures);
            await _dbContext.SaveChangesAsync();
            return lectures.IdLecture;
        }
        public async Task<Resources> AddLecturesVideo(IFormFile videoFile, string id)
        {
            var res = new Resources();
            Random rd = new Random();
            res.IdResources = "TN"+rd.Next(1,9)+rd.Next(10,99);
            res.StatusFile = false;
            res.DateSent = DateTime.Now;
            res.IdLecture = id;
            if (videoFile == null || videoFile.Length == 0)
            {
                throw new ArgumentException("No file selected");
            }
            if (videoFile.ContentType != "video/mp4")
            {
                throw new ArgumentException("Invalid file type");
            }
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            using (FileStream fileStream = System.IO.File.Create(path + videoFile.FileName))
            {
                videoFile.CopyTo(fileStream);
                fileStream.Flush();
                res.FormatFile = videoFile.ContentType;
                res.FileURL = videoFile.FileName;
            }
            _dbContext.Add(res);
            await _dbContext.SaveChangesAsync();
            return res;
        }

        public Task PhanCongTL(IFormFile filedetail, string id)
        {
            throw new NotImplementedException();
        }

        public async Task DuyetTaiLieu(string id,bool check)
        {
            var tailieu = _dbContext.Resources.Where(t => t.IdResources == id).FirstOrDefault();
            if(tailieu!=null)
            {
                tailieu.StatusFile = check;
                await _dbContext.SaveChangesAsync();
            }    
        }

        #endregion

        //Resource
        #region
        public List<Resources> GetAllResources()
        {
            return _dbContext.Resources.ToList();
        }
        public List<Resources> GetResourcesForIdLectures(string idLec)
        {
            return _dbContext.Resources.Where(t=>t.IdLecture==idLec).ToList();
        }

        public async Task<Resources> AddFileResource(IFormFile filedetail, string id)
        {
            var res = new Resources();
            Random rd = new Random();
            res.IdResources = "TN" + rd.Next(1, 9) + rd.Next(10, 99);
            res.StatusFile = false;
            res.DateSent = DateTime.Now;
            res.IdLecture = id;

            if (filedetail == null || filedetail.Length == 0)
            {
                throw new ArgumentException("No file selected");
            }


            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            using (FileStream fileStream = System.IO.File.Create(path + filedetail.FileName))
            {
                filedetail.CopyTo(fileStream);
                fileStream.Flush();
                res.FormatFile = filedetail.ContentType;
                res.FileURL = filedetail.FileName;

            }

            _dbContext.Add(res);
            await _dbContext.SaveChangesAsync();
            return res;
        }
        public Task<Resources> DetailResource(string id)
        {
            return _dbContext.Resources.Where(t => t.IdResources == id).FirstOrDefaultAsync();
        }
        public Task<Resources> GetResourceByName(string name)
        {
            return _dbContext.Resources.Where(t => t.FileURL == name).FirstOrDefaultAsync();
        }
        public void DeleteResource(string id)
        {
            var video = _dbContext.Resources.SingleOrDefault(t => t.IdResources == id);
            if (video != null)
            {
                _dbContext.Remove(video);
                _dbContext.SaveChanges();
            }
        }
        #endregion

        //Questions
        #region
        public List<Questions> GetAllQuestionForLectures(string idLec)
        {
            List<ClassAssignment> list=_dbContext.classAssignments.Where(t=>t.IdLectures == idLec).ToList();
            List<Questions> ques = new List<Questions>();
            foreach(var item in list)
            {
                var question = _dbContext.questions.Where(t => t.IdPC == item.IdPC).FirstOrDefault();
                ques.Add(question);
            }
            return ques;
        }

        public async Task<Questions> AddQuestions(Questions ques,string idClass,string idUser)
        {
            Random rd = new Random();
            ques.IdQuestions = "CH" + rd.Next(1, 9) + rd.Next(10, 99);
            ques.DateCreate = DateTime.Now;
            ques.Favorite = false;
            var l = _dbContext.classAssignments.Where(t => t.IdClass == idClass).FirstOrDefault();
            ques.IdPC = l.IdPC;
            ques.IdUser = idUser;
            _dbContext.Add(ques);
            _dbContext.SaveChanges();
            return ques;


        }

        public Task<Questions> EditQuestions(Questions ques)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteQuestion(string id)
        {
            var ques = await _dbContext.questions.Where(t => t.IdQuestions == id).FirstOrDefaultAsync();
            if (ques == null)
                return false;
            _dbContext.Remove(ques);
            _dbContext.SaveChanges();
            return true;
        }


        #endregion

      
        //Class
        #region
        public List<ClassSubject> GetAllClass()
        {
            return _dbContext.classSubjects.ToList();
        }

        public async Task<ClassSubject> AddClass(ClassSubject classSubject)
        {
            classSubject.IdClass = RandomId("LH");
            _dbContext.Add(classSubject);
            _dbContext.SaveChanges();
            return  classSubject;
        }

        public Task<ClassSubject> EditClass(ClassSubject classSubject)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteClass(string id)
        {
            var l =  _dbContext.classSubjects.SingleOrDefault(t => t.IdClass == id);
            if (l != null)
            {
                _dbContext.Remove(l);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void AddClassSubject(DetailClass detail)
        {
           _dbContext.Add(detail);
            _dbContext.SaveChanges();
        }

        public void AddStudentToClass(string idStudent,string l)
        {
            var detai = new ClassList();
            detai.IdStudent = idStudent;
            detai.IdClass = l;
            _dbContext.Add(detai);
            _dbContext.SaveChanges();
        }

        public Task<ClassSubject> GetClass(string idClass)
        {
            return _dbContext.classSubjects.Where(t=>t.IdClass==idClass).FirstOrDefaultAsync();
        }
        public List<ClassSubject> GetAllClassForTeacher(string idTeacher, string idSubject)
        {
            List<DetailClass> list = _dbContext.detailClasses.Where(t => t.IdTeacher == idTeacher && t.IdSubject == idSubject).ToList();
            List<ClassSubject> result = new List<ClassSubject>();
            foreach (var item in list)
            {
                var detail = _dbContext.classSubjects.FirstOrDefault(t => t.IdClass == item.IdClass);
                result.Add(detail);

            }
            return result;
        }

        public List<ClassList> ListStudent(string idClass)
        {
            return _dbContext.classLists.Where(t=>t.IdClass==idClass).ToList();
        }

        
        public void AddStudentToClass()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
