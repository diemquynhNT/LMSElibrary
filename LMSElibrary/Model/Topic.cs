using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    public class Topic
    {
        [Key]
        public string IdTopic { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? IdSubject { get; set; }
        public Subject subjects { get; set; }

        public virtual ICollection<Document> documents { get; set; }

    }
}
