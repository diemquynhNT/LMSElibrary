using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class Resources
    {
        [Key]
        public string IdResources { get; set; }
        [Required]
        [MaxLength(100)]
        public string FormatFile { get; set; }
    }
}
