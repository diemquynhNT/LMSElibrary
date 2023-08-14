using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    [Table("Document")]
    public class Document
    {
        [Key]
        public string IdDocument { get; set; }
        [Required]
        [MaxLength(100)]
        public string TitleDoc { get; set; }

        public string? IdTopic { get; set; }
        [ForeignKey("IdTopic")]
        public Topic topics { get; set; }

        public string? IdClass { get; set; }
        [ForeignKey("IdClass")]
        public SubjectClass subclass { get; set; }

    }
}
