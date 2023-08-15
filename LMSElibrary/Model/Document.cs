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
        public Topic topics { get; set; }

        public string? IdClass { get; set; }
        public SubjectClass subclass { get; set; }

        public virtual ICollection<Resources> resources { get; set; }


    }
}
