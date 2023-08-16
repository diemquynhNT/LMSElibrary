using SubjectService.Model;

namespace SubjectService.Service
{
    public interface ISubjectService
    {
        public List<MonHoc> GetSubjectListAsync();
        public Task<MonHoc> GetSubjectByIdAsync(string id);
        public Task<MonHoc> GetSubjectByName(string id);
        public List<ChuDe> GetTopicsSubject(string id);
        public List<BaiGiang> GetDocment(string id);

        public Task AddTopic(string nametopic,string id);
        public Task EditTopic(string nametopic, string id,string idtopic);
        public void DeleteTopic(string id,string idtopic);

        public Task AddDocument(string title, string idtopic);
        public Task EditDocument(string title, string iddoc, string idtopic);
        public void DeleteDocument(string iddoc, string idtopic);

        public Task AddVideo(IFormFile videoFile, string id);
        public List<Resources> GetVideo();
        public void DeleteVideo(string id);




    }
}
