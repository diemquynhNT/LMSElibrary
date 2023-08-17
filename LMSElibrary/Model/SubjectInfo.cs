using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class SubjectInfo
    {
        [Key]
        public string IdSubjectInfo { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string ContentSubject { get; set; }

        public string? IdSubject { get; set; }
        public Subject subjects { get; set; }

    }
}
