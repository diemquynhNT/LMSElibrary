using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class Questions
    {
        [Key]
        public string IdQuestions { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string ContentQuestion { get; set; }
        public string? IdUser { get; set; }
        public DateTime DateCreate { get; set; }
        public bool Favorite { get; set; }

        public string? IdPC { get; set; }
        public ClassAssignment classAssignment { get; set; }

    }
}
