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
        public string? Describe { get; set; }
        public string? Usercheck { get; set; }
        public string? FileURL { get; set; }
        public byte statusResource { get; set; }
        public string? NoteRes { get; set; }
        public DateTime sentdate { get; set; }

        public string? IdDocument { get; set; }
        public BaiGiang documents { get; set; }

    }
}
