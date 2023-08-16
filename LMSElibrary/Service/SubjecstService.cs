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
            
            var doc = new BaiGiang();
            doc.IdBaiGiang = Guid.NewGuid().ToString();
            doc.TitleBaiGiang = title;
            doc.IdChuDe = idtopic;
            _dbContext.Add(doc);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddTopic(string nametopic, string id)
        {
            try {
                Random rd = new Random();
                var tp = new ChuDe();
                tp.IdChuDe=Guid.NewGuid().ToString();
                tp.Title = nametopic;
                tp.IdMonHoc=id;
                _dbContext.Add(tp);
                await _dbContext.SaveChangesAsync();
            }
            catch {
                throw;    
            }
        }

        public void DeleteDocument(string iddoc, string idtopic)
        {
            var doc = _dbContext.baiGiangs.SingleOrDefault(t => t.IdChuDe == idtopic && t.IdBaiGiang == iddoc);
            if (doc != null)
            {
                _dbContext.Remove(doc);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteTopic(string id, string idtopic)
        {
            var topic = _dbContext.chuDes.SingleOrDefault(t => t.IdChuDe == idtopic &&t.IdMonHoc==id);
            if (topic != null)
            {
                _dbContext.Remove(topic);
                _dbContext.SaveChanges();
            }
        }

        public async Task EditDocument(string title, string iddoc, string idtopic)
        {
            var tp = _dbContext.baiGiangs.Where(t => t.IdChuDe == idtopic && t.IdBaiGiang == iddoc).FirstOrDefault();
            if (title != null)
            {
                tp.TitleBaiGiang = title;
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task EditTopic(string nametopic, string id, string idtopic)
        {
           var tp=_dbContext.chuDes.Where(t=>t.IdChuDe ==idtopic && t.IdMonHoc==id).FirstOrDefault();
            if(nametopic!=null)
            {
                tp.Title=nametopic;
                await _dbContext.SaveChangesAsync();

            }    
        }

        public List<Lop> GetClassForTeacher(string id, string idgv)
        {
            return _dbContext.Lops.Where(t => t.IdMonHoc == id).ToList();
        }

        public List<BaiGiang> GetDocment(string id)
        {
            return _dbContext.baiGiangs.Where(t => t.IdChuDe == id).ToList();
        }

        public async Task<MonHoc> GetSubjectByIdAsync(string id)
        {
            return await _dbContext.monHocs.Where(x => x.IdMonHoc == id).FirstOrDefaultAsync();
        }

        public async Task<MonHoc> GetSubjectByName(string id)
        {
            return await _dbContext.monHocs.Where(x => x.TenMonHoc == id).FirstOrDefaultAsync();
        }

        

        public List<MonHoc> GetSubjectListAsync()
        {
            return _dbContext.monHocs.ToList();
        }


        public List<ChuDe> GetTopicsSubject(string id)
        {
            return _dbContext.chuDes.Where(t=>t.IdMonHoc==id).ToList();
        }
    }
}
