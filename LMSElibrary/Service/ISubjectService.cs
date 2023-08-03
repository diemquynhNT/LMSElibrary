using SubjectService.Model;

namespace SubjectService.Service
{
    public interface ISubjectService
    {
        public Task<IEnumerable<Subject>> GetSubjectListAsync();
        public Task<Subject> GetSubjectByIdAsync(string id);
    }
}
