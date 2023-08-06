using PersonalfilesService.Model;
using static PersonalfilesService.Model.FileDetails;
using static PersonalfilesService.Model.FileUploadModel;

namespace PersonalfilesService.Service
{
    public interface IFileService
    {
        public Task PostFileAsync(IFormFile fileData, FileType fileType);

        public Task PostMultiFileAsync(List<FileUploadModel> fileData);

        public Task DownloadFileById(int id);
        public Task DeleteFileById(int id);
    }
}
