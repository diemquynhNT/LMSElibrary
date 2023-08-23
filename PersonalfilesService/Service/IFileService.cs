using PersonalfilesService.Model;
using static PersonalfilesService.Model.FileDetails;

namespace PersonalfilesService.Service
{
    public interface IFileService
    {
        public List<FileDetails> GetAlFile();
        public Task<FileDetails> EditFile(int id);
        public Task<FileDetails> GetFileById(int id);
        public Task<FileDetails> PostFileAsync(string idUser, IFormFile fileData);
        //public Task PostMultiFileAsync(List<FileUploadModel> fileData);
        public Task<FileDetails> DownloadFileById(int id);
        public Task<bool> DeleteFileById(int id);
    }
}
