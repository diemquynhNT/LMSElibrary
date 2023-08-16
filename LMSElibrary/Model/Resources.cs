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
        public string? DescribeFile { get; set; }
        public string? UserCheck { get; set; }
        public string? FileURL { get; set; }
        public bool StatusFile { get; set; }
        public string? NoteRes { get; set; }
        public DateTime DateSent { get; set; }

        public string? IdLecture { get; set; }
        public Lectures lectures { get; set; }

    }
}
