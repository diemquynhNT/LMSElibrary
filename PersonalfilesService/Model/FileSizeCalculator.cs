namespace PersonalfilesService.Model
{
    public class FileSizeCalculator
    {
        public long CalculateFileSize(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return file.Length;
            }

            return 0;
        }
    }
}
