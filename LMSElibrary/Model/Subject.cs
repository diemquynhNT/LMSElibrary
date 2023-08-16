using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    public class MonHoc
    {
        [Key]
        public string IdMonHoc { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenMonHoc { get; set; }
        public string NienKhoa { get; set; }
        public string? Mota { get; set; }

        public bool TrangThai { get; set; }

        public string? IdBoMon { get; set; }
        public BoMon BoMon { get; set; }

        public virtual ICollection<ThongtinMonHoc> ttmh { get; set; }
        public virtual ICollection<ChuDe> topics { get; set; }
        public virtual ICollection<ChitietLop> ctlop { get; set; }
        // khi tạo có thể null ctdh
        //public MonHoc()
        //{
        //    ctlop = new HashSet<ChitietLop>();
        //}



    }
}
