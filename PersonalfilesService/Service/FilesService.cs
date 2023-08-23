using Microsoft.EntityFrameworkCore;
using PersonalfilesService.Data;
using PersonalfilesService.Model;
using System.IO;
using static System.Net.WebRequestMethods;

namespace PersonalfilesService.Service
{
    public class FilesService : IFileService
    {
        private readonly MyDBContext dbContextClass;

        public FilesService(MyDBContext dbContextClass)
        {
            this.dbContextClass = dbContextClass;
        }

        //    public async Task DownloadFileById(int id)
        //    {
        //        try
        //        {
        //            //var file = dbContextClass.fileDetails.Where(x => x.IdFile == id).FirstOrDefaultAsync();

        //            //var content = new System.IO.MemoryStream(file.Result.FileURL);
        //            //var path = Path.Combine(
        //            //   Directory.GetCurrentDirectory(), "FileDownloaded",
        //            //   file.Result.FileName);

        //            //await CopyStream(content, path);
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //    public async Task CopyStream(Stream stream, string downloadPath)
        //    {
        //        using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
        //        {
        //            await stream.CopyToAsync(fileStream);
        //        }
        //    }

        //    public async Task PostFileAsync(IFormFile fileData, FileType fileType)
        //    {
        //        try
        //        {
        //            //FileSizeCalculator calculator = new FileSizeCalculator();
        //            //long fileSizeInBytes = calculator.CalculateFileSize(fileData);

        //            //var fl = new FileDetails()
        //            //{
        //            //    IdFile = 0,
        //            //    FileName = fileData.FileName,
        //            //    Creator="YB",
        //            //    Datecreated = DateTime.Now,
        //            //    SizeFile=fileSizeInBytes.ToString(),
        //            //    Filetypes = fileType,
        //            //};

        //            //using (var stream = new MemoryStream())
        //            //{
        //            //    fileData.CopyTo(stream);
        //            //    fl.FileData = stream.ToArray();
        //            //}

        //            //var result = dbContextClass.fileDetails.Add(fl);
        //            //await dbContextClass.SaveChangesAsync();
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }

        //    public Task PostMultiFileAsync(List<FileUploadModel> fileData)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task DeleteFileById(int id)
        //    {
        //        var file = await dbContextClass.fileDetails.FindAsync(id);

        //        if (file != null)
        //        {
        //            dbContextClass.fileDetails.Remove(file);
        //            await dbContextClass.SaveChangesAsync();
        //        }
        //    }

        //    public List<FileDetails> GetAlFile()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<FileDetails> EditFile()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task PostFileAsync(IFormFile fileData)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
