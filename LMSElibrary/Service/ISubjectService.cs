using SubjectService.Model;

namespace SubjectService.Service
{
    public interface ISubjectService
    {
        public List<Subject> GetAllSubject();
        public List<Subject> GetAllSubjectForTeacher(string idTeacher);
        public List<ClassSubject> GetAllClassForTeacher(string idTeacher,string idSubject);
        public List<Resources> GetAllResources();
        public List<Resources> GetResourceByName(string name);
        public Task<Subject> GetSubjectByIdAsync(string id);
        public Task<Subject> GetSubjectByName(string id);
        public List<Topic> GetTopicsSubject(string id);
       


        //chủ đề
        public Task AddTopic(string nametopic,string id);
        public Task EditTopic(string nametopic, string id,string idtopic);
        public void DeleteTopic(string id,string idtopic);

        //Lectures
        public List<Lectures> GetLectures(string idtopic);
        public Task<string> AddLecture(Lectures lectures);
        //public Task EditDocument(string title, string iddoc, string idtopic);
        public void DeleteLecture(string iddoc, string idtopic);
        // Resources
        public Task<Resources> DetailResource(string id);
        public Task<Resources> AddLecturesVideo(IFormFile videoFile, string id);
        public List<Resources> GetVideo();
        public void DeleteResource(string id);
        public Task<Resources> AddFileResource(IFormFile filedetail, string id);
        public Task PhanCongTL(IFormFile filedetail, string id);
        public Task DuyetTaiLieu(string id, bool check);
        // Question
        public List<Questions> GetAllQuestionForLectures(string idLec);
        public Task<Questions> AddQuestions(Questions ques);
        public Task<Questions> EditQuestions(Questions ques);
        public Task<bool> DeleteQuestion(string id);



    }
}
