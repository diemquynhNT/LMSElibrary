using Microsoft.AspNetCore.Mvc;
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

        public async Task AddTopic(string nametopic, string id)
        {
            try {
                Random rd = new Random();
                var tp = new Topic();
                tp.IdTopic=Guid.NewGuid().ToString();
                tp.Title = nametopic;
                tp.IdSubject=id;
                _dbContext.Add(tp);
                await _dbContext.SaveChangesAsync();
            }
            catch {
                throw;    
            }
        }

        public async Task EditTopic(string nametopic, string id, string idtopic)
        {
           var tp=_dbContext.Topics.Where(t=>t.IdTopic==idtopic && t.IdSubject==id).FirstOrDefault();
            if(nametopic!=null)
            {
                tp.Title=nametopic;
                await _dbContext.SaveChangesAsync();

            }    
        }

        public List<SubjectClass> GetClassForTeacher(string id, string idgv)
        {
            return _dbContext.SubjectClasses.Where(t => t.IdSubject == id).ToList();
        }

        public async Task<Subject> GetSubjectByIdAsync(string id)
        {
            return await _dbContext.Subjects.Where(x => x.IdSubject == id).FirstOrDefaultAsync();
        }

        public async Task<Subject> GetSubjectByName(string id)
        {
            return await _dbContext.Subjects.Where(x => x.NameSubject == id).FirstOrDefaultAsync();
        }

        

        public List<Subject> GetSubjectListAsync()
        {
            return _dbContext.Subjects.ToList();
        }


        public List<Topic> GetTopicsSubject(string id)
        {
            return _dbContext.Topics.Where(t=>t.IdSubject==id).ToList();
        }
    }
}
