using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalfilesService.Model
{
    [Table("FileDetails")]
    public class FileDetails
    {
       
        [Key]
        public int IdFile { get; set; }
        public string FileName { get; set; }
        public string Creator { get; set; }
        public DateTime Datecreated { get; set; }
        public string SizeFile { get; set; }
        public byte[] FileData { get; set; }
        public FileType Filetypes { get; set; }
    }
}
