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
        public async Task AddLecture(string title, string idtopic)
        {
            var l = new Lectures();
            l.IdLecture = Guid.NewGuid().ToString();
            l.TitleLecture = title;
            l.IdTopic = idtopic;
            _dbContext.Add(l);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddVideo(IFormFile videoFile, string id)
        {
            var tn = new Resources();
            tn.IdResources = Guid.NewGuid().ToString();
            tn.StatusFile = false;
            tn.DateSent = DateTime.Now;
            tn.IdLecture = id;

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
                var tp = new Topic();
                tp.IdTopic=Guid.NewGuid().ToString();
                tp.TitleTopic = nametopic;
                tp.IdSubject=id;
                _dbContext.topics.Add(tp);
                await _dbContext.SaveChangesAsync();
            
        }

        public void DeleteLecture(string iddoc, string idtopic)
        {
            var doc = _dbContext.lectures.SingleOrDefault(t => t.IdTopic == idtopic && t.IdLecture == iddoc);
            if (doc != null)
            {
                _dbContext.Remove(doc);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteTopic(string id, string idtopic)
        {
            var topic = _dbContext.topics.SingleOrDefault(t => t.IdTopic == idtopic &&t.IdSubject==id);
            if (topic != null)
            {
                _dbContext.Remove(topic);
                _dbContext.SaveChanges();
            }
        }

        //public async Task EditDocument(string title, string iddoc, string idtopic)
        //{
        //    var tp = _dbContext.baiGiangs.Where(t => t.IdChuDe == idtopic && t.IdBaiGiang == iddoc).FirstOrDefault();
        //    if (title != null)
        //    {
        //        tp.TitleBaiGiang = title;
        //        await _dbContext.SaveChangesAsync();

        //    }
        //}

        public async Task EditTopic(string nametopic, string id, string idtopic)
        {
           var tp=_dbContext.topics.Where(t=>t.IdTopic ==idtopic && t.IdSubject==id).FirstOrDefault();
            if(nametopic!=null)
            {
                tp.TitleTopic=nametopic;
                await _dbContext.SaveChangesAsync();

            }    
        }

        //public List<Lop> GetClassForTeacher(string id, string idgv)
        //{
        //    return _dbContext.Lops.Where(t => t.IdMonHoc == id).ToList();
        //}

        public List<Lectures> GetDocment(string id)
        {
            return _dbContext.lectures.Where(t => t.IdTopic == id).ToList();
        }

        public async Task<Subject> GetSubjectByIdAsync(string id)
        {
            return await _dbContext.subjects.Where(x => x.IdSubject == id).FirstOrDefaultAsync();
        }

        public async Task<Subject> GetSubjectByName(string id)
        {
            return await _dbContext.subjects.Where(x => x.NameSubject == id).FirstOrDefaultAsync();
        }

        

        public List<Subject> GetSubjectListAsync()
        {
            return _dbContext.subjects.ToList();
        }


        public List<Topic> GetTopicsSubject(string id)
        {
            return _dbContext.topics.Where(t=>t.IdSubject==id).ToList();
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
