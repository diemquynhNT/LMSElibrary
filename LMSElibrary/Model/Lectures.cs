using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    [Table("Lectures")]
    public class Lectures
    {
        [Key]
        public string IdLecture { get; set; }
        [Required]
        [MaxLength(100)]
        public string TitleLecture { get; set; }

        public string? Describe { get; set; }

        public string? IdTopic { get; set; }
        public Topic topics { get; set; }

        public virtual ICollection<ClassAssignment> detailLectures { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        // khi tạo có thể null ctdh
        public Lectures()
        {
            detailLectures = new HashSet<ClassAssignment>();
        }
        public virtual ICollection<Resources> resources { get; set; }


    }
}
