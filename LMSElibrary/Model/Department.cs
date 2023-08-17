using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SubjectService.Model
{
    public class Department
    {
        [Key]
        public string IdDepartment { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameDepartment { get; set; }

        public virtual ICollection<Subject> subjects { get; set; }
    }
}
