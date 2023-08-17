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
        public string Schoolyear { get; set; }
        public string? DescribeSubject { get; set; }

        public bool StatusSubject { get; set; }

        public string? IdDepartment { get; set; }
        public Department department { get; set; }

        public virtual ICollection<SubjectInfo> subjectInfos { get; set; }
        public virtual ICollection<Topic> topics { get; set; }
        public virtual ICollection<DetailClass> detailClass { get; set; }
        // khi tạo có thể null ctdh
        //public MonHoc()
        //{
        //    ctlop = new HashSet<ChitietLop>();
        //}



    }
}
