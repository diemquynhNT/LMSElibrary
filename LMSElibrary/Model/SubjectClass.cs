using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    [Table("Class")]
    public class SubjectClass
    {
        [Key]
        public string IdClass { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameClass { get; set; }

        public string? IdSubject { get; set; }
        public string? IdTeacher { get; set; }

        public Subject Subjects { get; set; }
        public virtual ICollection<Document> documents { get; set; }
        public virtual ICollection<DetailClass> DetailClasses { get; set; }






    }
}
