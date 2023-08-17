using SubjectService.Model;

namespace SubjectService.Service
{
    public interface ISubjectService
    {
        public List<Subject> GetSubjectListAsync();
        public Task<Subject> GetSubjectByIdAsync(string id);
        public Task<Subject> GetSubjectByName(string id);
        public List<Topic> GetTopicsSubject(string id);
        public List<Lectures> GetDocment(string id);

        public Task AddTopic(string nametopic,string id);
        public Task EditTopic(string nametopic, string id,string idtopic);
        public void DeleteTopic(string id,string idtopic);

        public Task AddLecture(string title, string idtopic);
        //public Task EditDocument(string title, string iddoc, string idtopic);
        public void DeleteLecture(string iddoc, string idtopic);

        public Task AddVideo(IFormFile videoFile, string id);
        public List<Resources> GetVideo();
        public void DeleteVideo(string id);




    }
}
