using SubjectService.Data;
using SubjectService.Migrations;
using SubjectService.Model;

namespace SubjectService.Service
{
    public interface ISubjectService
    {
        public List<Subject> GetSubjectListAsync();
        public Task<Subject> GetSubjectByIdAsync(string id);
        public Task<Subject> GetSubjectByName(string id);
        public List<Topic> GetTopicsSubject(string id);

        public Task AddTopic(string nametopic,string id);
        public Task EditTopic(string nametopic, string id,string idtopic);


    }
}
