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

        public async Task AddDocument(string title, string idtopic)
        {
            
            var doc = new Documents();
            doc.IdDocument = Guid.NewGuid().ToString();
            doc.TitleDoc = title;
            doc.IdTopic = idtopic;
            _dbContext.Add(doc);
            await _dbContext.SaveChangesAsync();
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

        public void DeleteDocument(string iddoc, string idtopic)
        {
            var doc = _dbContext.Documents.SingleOrDefault(t => t.IdTopic == idtopic && t.IdDocument == iddoc);
            if (doc != null)
            {
                _dbContext.Remove(doc);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteTopic(string id, string idtopic)
        {
            var topic = _dbContext.Topics.SingleOrDefault(t => t.IdTopic == idtopic &&t.IdSubject==id);
            if (topic != null)
            {
                _dbContext.Remove(topic);
                _dbContext.SaveChanges();
            }
        }

        public async Task EditDocument(string title, string iddoc, string idtopic)
        {
            var tp = _dbContext.Documents.Where(t => t.IdTopic == idtopic && t.IdDocument == iddoc).FirstOrDefault();
            if (title != null)
            {
                tp.TitleDoc = title;
                await _dbContext.SaveChangesAsync();

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

        public List<Documents> GetDocment(string id)
        {
            return _dbContext.Documents.Where(t => t.IdTopic == id).ToList();
        }

        public async Task<MonHoc> GetSubjectByIdAsync(string id)
        {
            return await _dbContext.Subjects.Where(x => x.IdSubject == id).FirstOrDefaultAsync();
        }

        public async Task<MonHoc> GetSubjectByName(string id)
        {
            return await _dbContext.Subjects.Where(x => x.NameSubject == id).FirstOrDefaultAsync();
        }

        

        public List<MonHoc> GetSubjectListAsync()
        {
            return _dbContext.Subjects.ToList();
        }


        public List<Topic> GetTopicsSubject(string id)
        {
            return _dbContext.Topics.Where(t=>t.IdSubject==id).ToList();
        }
    }
}
