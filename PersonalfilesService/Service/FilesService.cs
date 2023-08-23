using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PersonalfilesService.Data;
using PersonalfilesService.Model;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace PersonalfilesService.Service
{
    public class FilesService : IFileService
    {
        private readonly MyDBContext _context;
        public static IWebHostEnvironment _webHostEnvironment;

        public FilesService(MyDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        //public void DownloadFileById(int id)
        //{
        //    var file = _context.fileDetails.Where(x => x.IdFile == id).FirstOrDefault();



        //    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, file.FileName);

        //    //byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

        //    // Định dạng MIME type của file
        //    //string mimeType = MimeTypes.GetMimeType(Path.GetExtension(filePath));

        //    // Trả về file cho client
        //    //return File(fileBytes, mimeType, fileName);

        //    //var content = new System.IO.MemoryStream(await System.IO.File.ReadAllBytesAsync(file.FileName));
        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "FileDownloaded", file.FileName);

        //     CopyStream(filePath, path);
        //    return file;

        //}
        

        public async Task DownloadFileById(int id)
        {
            var fl = _context.fileDetails.FirstOrDefault(x => x.IdFile == id);
            if (fl == null)
            {
                throw new FileNotFoundException("File not found");
            }
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, fl.FileName);

            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found");
            }
            
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public async Task<FileDetails> PostFileAsync(string idUser,IFormFile fileData)
        {
            try
            {
                FileSizeCalculator calculator = new FileSizeCalculator();
                long fileSizeInBytes = calculator.CalculateFileSize(fileData);
            
                var fl = new FileDetails()
                {
                    IdFile = 0,
                    FileName = fileData.FileName,
                    Creator = idUser,
                    Datecreated = DateTime.Now,
                    SizeFile = fileSizeInBytes.ToString(),
                };

                if (fileData.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);

                    }
                    using (FileStream fileStream = System.IO.File.Create(path + fileData.FileName))
                    {
                        fileData.CopyTo(fileStream);
                        fileStream.Flush();
                        fl.FileURL = path + fileData.FileName;
                        fl.Filetypes = fileData.ContentType;

                    }
                }
                _context.fileDetails.Add(fl);
                await _context.SaveChangesAsync();
                return fl;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task PostMultiFileAsync(List<FileDetails> fileData)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteFileById(int id)
        {
            var file = await _context.fileDetails.FindAsync(id);

            if (file == null)
                return false;
            _context.fileDetails.Remove(file);
            await _context.SaveChangesAsync();
            return true;

        }

        public List<FileDetails> GetAlFile()
        {
            return _context.fileDetails.ToList();
        }

        public async Task<FileDetails> EditFile(int id)
        {
            var fl =  _context.fileDetails.Where(t=>t.IdFile==id).FirstOrDefault();
            _context.fileDetails.Update(fl);
            await _context.SaveChangesAsync();
            return fl;

        }

        public Task PostFileAsync(IFormFile fileData)
        {
            throw new NotImplementedException();
        }

        public async Task<FileDetails> GetFileById(int id)
        {
            return await _context.fileDetails.Where(t => t.IdFile == id).FirstOrDefaultAsync();
        }

        Task<FileDetails> IFileService.DownloadFileById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

