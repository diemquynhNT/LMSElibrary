using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class ClassAssignment
    {
        [Key]
        public string IdPC { get; set; }
        public string IdClass { get; set; }
        public string IdLectures { get; set; }

        public Lectures lectures { get; set; }
        public ClassSubject classSubjects { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
