using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalfilesService.Model
{
    [Table("FileDetails")]
    public class FileDetails
    {
        [Key]
        public int IdFile { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Creator { get; set; }
        public DateTime Datecreated { get; set; }
        public string SizeFile { get; set; }
        public string FileURL { get; set; }
       // public FileType Filetypes { get; set; }
    }
}
