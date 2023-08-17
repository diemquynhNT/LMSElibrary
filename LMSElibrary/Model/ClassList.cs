using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class ClassList
    {
        [Key]
        public string IdClassList { get; set; }

        public string? IdClass { get; set; }
        public ClassSubject classSubject { get; set; }
        public string? IdStudent { get; set; }
    }
}
