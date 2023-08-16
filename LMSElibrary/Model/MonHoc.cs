using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    public class Subject
    {
        [Key]
        public string IdSubject { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameSubject { get; set; }
        public string SchoolYear { get; set; }
        public string? Describe { get; set; }

        public byte Status { get; set; }

        public string? IdBoMon { get; set; }
     


        public BoMon BoMon { get; set; }

        public virtual ICollection<Topic> topics { get; set; }
        public virtual ICollection<SubjectClass> subjectclass { get; set; }



    }
}
