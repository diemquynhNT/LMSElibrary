using SubjectService.Model;
using System.Diagnostics.Eventing.Reader;

namespace SubjectService.Service
{
    public interface ISubjectService
    {
        //Subject
        #region
        public List<Subject> GetAllSubject();
        public List<Department> GetAllDepartment();
        public List<Subject> GetAllSubjectForTeacher(string idTeacher);
        public Task<Subject> GetSubjectByIdAsync(string id);
        public Task<Subject> GetSubjectByName(string id);
        public Task<Subject> AddSubject(Subject subject);
        public Task<Subject> UpdateSubject(Subject subject);
        public Task<bool> DeleteSubject(string id);

        #endregion


        //Topic
        #region
        public List<Topic> GetTopicsSubject(string id);
        public Task<Topic> AddTopic(string nametopic,string idSubject);
        public Task<Topic> EditTopic(string nametopic, string idTopic);
        public Task<bool> DeleteTopic(string id);
        #endregion

        //Lectures
        #region
        public List<Lectures> GetLectures(string idtopic);
        public Task<string> AddLecture(Lectures lectures);
        //public Task EditDocument(string title, string iddoc, string idtopic);
        public void DeleteLecture(string iddoc, string idtopic);
        #endregion

        // Resources
        #region
        public List<Resources> GetAllResources();
        public List<Resources> GetResourcesForIdLectures(string idLec);
        //public List<Resources> GetResourceByName(string name);
        public Task<Resources> DetailResource(string id);
        public Task<Resources> AddLecturesVideo(IFormFile videoFile, string id);
        public List<Resources> GetVideo();
        public void DeleteResource(string id);
        public Task<Resources> AddFileResource(IFormFile filedetail, string id);

        public Task<ClassAssignment> PhanCongTL(string idClass,string idLectures);

        public Task DuyetTaiLieu(string id, bool check);
        #endregion
        // Question
        #region
        public List<Questions> GetAllQuestionForLectures(string idLec, string idClass);
        public Task<Questions> AddQuestions(Questions ques, string idClass, string idUser,string idLectures);
        public Task<Questions> EditQuestions(Questions ques);
        public Task<bool> DeleteQuestion(string id);
        #endregion

        //Class
        #region
        public List<ClassSubject> GetAllClass();
        public List<ClassAssignment> GetAllPC();
        public List<DetailClass> GetAllClassForSubject(string idSubject);
        public Task<ClassSubject> GetClass(string idClass);
        public Task<ClassSubject> AddClass(ClassSubject classSubject);
        public Task<DetailClass> AddDetailClassSubject(string idSubject, string idClass);
        public Task<ClassSubject> EditClass(ClassSubject classSubject);
        public Task<bool> DeleteClass(string id);
        public List<ClassList> ListStudent(string idClass);
        public void AddClassSubject(DetailClass detail);
        public void AddStudentToClass();
        public List<ClassSubject> GetAllClassForTeacher(string idTeacher, string idSubject);
        #endregion
    }
}
