using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    [Table("Class")]
    public class Lop
    {
        [Key]
        public string IdLop { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenLop { get; set; }

        public string? IdMonHoc { get; set; }
        public string? IdTeacher { get; set; }

        public MonHoc Subjects { get; set; }
        public virtual ICollection<BaiGiang> documents { get; set; }
        public virtual ICollection<DanhsachLop> dslop { get; set; }
        public virtual ICollection<ChitietLop> ctlop { get; set; }
        public virtual ICollection<ChiTietBaiGiang> ctbg { get; set; }
        // khi tạo có thể null ctdh
        public Lop()
        {
            ctlop = new HashSet<ChitietLop>();
            ctbg = new HashSet<ChiTietBaiGiang>();
        }


        
       




    }
}
