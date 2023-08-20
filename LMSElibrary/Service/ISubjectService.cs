using SubjectService.Model;

namespace SubjectService.Service
{
    public interface ISubjectService
    {
        public List<Subject> GetSubjectListAsync();
        public Task<Subject> GetSubjectByIdAsync(string id);
        public Task<Subject> GetSubjectByName(string id);
        public List<Topic> GetTopicsSubject(string id);
        public List<Resources> GetResources();

        //chủ đề
        public Task AddTopic(string nametopic,string id);
        public Task EditTopic(string nametopic, string id,string idtopic);
        public void DeleteTopic(string id,string idtopic);

        //bài giàng
        public List<Lectures> GetLectures(string idtopic);
        public Task<string> AddLecture(string title, string idtopic,string des);
        //public Task EditDocument(string title, string iddoc, string idtopic);
        public void DeleteLecture(string iddoc, string idtopic);
        // tài nguyên
        public Task AddVideo(IFormFile videoFile, string id);
        public List<Resources> GetVideo();
        public void DeleteResource(string id);
        public Task AddFile(IFormFile filedetail, string id);
        public Task PhanCongTL(IFormFile filedetail, string id);
        public Task DuyetTaiLieu(string id, bool check);



    }
}
