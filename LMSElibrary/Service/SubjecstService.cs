using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubjectService.Data;
using SubjectService.Model;

namespace SubjectService.Service
{
    public class SubjecstService : ISubjectService
    {
        private readonly MyDbContext _dbContext;
        public static IWebHostEnvironment _webHostEnvironment;
        private object _context;

        public SubjecstService(MyDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;

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

        public async Task AddVideo(IFormFile videoFile, string id)
        {
            var tn = new Resources();
            tn.IdResources = Guid.NewGuid().ToString();
            tn.TinhTrangDuyet = false;
            tn.NgayGui = DateTime.Now;
            tn.IdBaiGiang = id;

            if (videoFile == null || videoFile.Length == 0)
            {
                throw new ArgumentException("No file selected");
            }

            if (videoFile.ContentType != "video/mp4")
            {
                throw new ArgumentException("Invalid file type");
            }

            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            using (FileStream fileStream = System.IO.File.Create(path + videoFile.FileName))
            {
                videoFile.CopyTo(fileStream);
                fileStream.Flush();
                tn.FormatFile = videoFile.ContentType;
                tn.FileURL = videoFile.FileName;

            }
           
            _dbContext.Add(tn);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddTopic(string nametopic, string id)
        {
          
                Random rd = new Random();
                var tp = new ChuDe();
                tp.IdChuDe=Guid.NewGuid().ToString();
                tp.Title = nametopic;
                tp.IdMonHoc=id;
                _dbContext.chuDes.Add(tp);
                await _dbContext.SaveChangesAsync();
            
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

        //public List<Lop> GetClassForTeacher(string id, string idgv)
        //{
        //    return _dbContext.Lops.Where(t => t.IdMonHoc == id).ToList();
        //}

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

        public List<Resources> GetVideo()
        {
            return _dbContext.Resources.Where(t=>t.FormatFile == "video/mp4").ToList();
            
        }

        public void DeleteVideo(string id)
        {
            var video = _dbContext.Resources.SingleOrDefault(t => t.IdResources==id && t.FormatFile == "video/mp4");
            if (video != null)
            {
                _dbContext.Remove(video);
                _dbContext.SaveChanges();
            }
        }
    }
}
