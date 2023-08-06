using static PersonalfilesService.Model.FileDetails;

namespace PersonalfilesService.Model
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FileType fileTypes { get; set; }
     
    }
}
