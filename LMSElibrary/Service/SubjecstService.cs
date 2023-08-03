using Microsoft.EntityFrameworkCore;
using SubjectService.Data;
using SubjectService.Model;

namespace SubjectService.Service
{
    public class SubjecstService : ISubjectService
    {
        private readonly MyDbContext _dbContext;

        public SubjecstService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subject> GetSubjectByIdAsync(string id)
        {
            return await _dbContext.Subjects.Where(x => x.IdSubject == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Subject>> GetSubjectListAsync()
        {
            return await _dbContext.Subjects.ToListAsync();
        }
    }
}
