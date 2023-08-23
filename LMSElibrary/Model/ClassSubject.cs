using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    [Table("Lop")]
    public class ClassSubject
    {
        [Key]
        public string IdClass { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameClass { get; set; }

        public virtual ICollection<Lectures> lectures { get; set; }
        public virtual ICollection<ClassList> dslop { get; set; }
        public virtual ICollection<DetailClass> detailClass { get; set; }
        public virtual ICollection<ClassAssignment> detailLectures { get; set; }
        // khi tạo có thể null ctdh
        public ClassSubject()
        {
            detailClass = new HashSet<DetailClass>();
            detailLectures = new HashSet<ClassAssignment>();
        }








    }
}
