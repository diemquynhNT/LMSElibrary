using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubjectService.Data;
using SubjectService.Dto;
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


        public async Task EditTopic(string nametopic, string id, string idtopic)
        {
           var tp=_dbContext.topics.Where(t=>t.IdTopic ==idtopic && t.IdSubject==id).FirstOrDefault();
            if(nametopic!=null)
            {
                tp.TitleTopic=nametopic;
                await _dbContext.SaveChangesAsync();

            }    
        }

       

        public List<Lectures> GetLectures(string id)
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

        public void DeleteResource (string id)
        {
            var video = _dbContext.Resources.SingleOrDefault(t => t.IdResources==id);
            if (video != null)
            {
                _dbContext.Remove(video);
                _dbContext.SaveChanges();
            }
        }

        public async Task AddFile(IFormFile filedetail, string id)
        {
            var tn = new Resources();
            tn.IdResources = Guid.NewGuid().ToString();
            tn.StatusFile = false;
            tn.DateSent = DateTime.Now;
            tn.IdLecture = id;

            if (filedetail == null || filedetail.Length == 0)
            {
                throw new ArgumentException("No file selected");
            }


            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            using (FileStream fileStream = System.IO.File.Create(path + filedetail.FileName))
            {
                filedetail.CopyTo(fileStream);
                fileStream.Flush();
                tn.FormatFile = filedetail.ContentType;
                tn.FileURL = filedetail.FileName;

            }

            _dbContext.Add(tn);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> AddLecture(string title,string id,string des)
        {
            var l = new Lectures();
            l.IdLecture = Guid.NewGuid().ToString();
            l.TitleLecture = title;
            l.Describe = des;
            l.IdTopic = id;
            _dbContext.Add(l);
            await _dbContext.SaveChangesAsync();
            return l.IdLecture;
        }

        public Task PhanCongTL(IFormFile filedetail, string id)
        {
            throw new NotImplementedException();
        }

        public async Task DuyetTaiLieu(string id,bool check)
        {
            var tailieu = _dbContext.Resources.Where(t => t.IdResources == id).FirstOrDefault();
            if(tailieu!=null)
            {
                tailieu.StatusFile = check;
                await _dbContext.SaveChangesAsync();
            }    
        }

        public List<Resources> GetResources()
        {
           return _dbContext.Resources.ToList();
        }

       
    }
}
