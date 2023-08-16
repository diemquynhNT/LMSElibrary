using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class DetailClass
    {
        [Key]
        public string IdDetailClass { get; set; }
        public string? IdClass { get; set; }
        public SubjectClass SubjectClass { get; set; }
        public string? IdStudent { get; set; }
    }
}
