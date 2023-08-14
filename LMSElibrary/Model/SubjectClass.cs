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

        public string? IdKhoa { get; set; }

        public string? IdSubject { get; set; }
        [ForeignKey("IdSubject")]
        public Subject subject { get; set; }



    }
}
