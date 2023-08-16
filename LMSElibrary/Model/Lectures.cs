using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    [Table("BaiGiang")]
    public class BaiGiang
    {
        [Key]
        public string IdBaiGiang { get; set; }
        [Required]
        [MaxLength(100)]
        public string TitleBaiGiang { get; set; }

        public string? MoTa { get; set; }

        public string? IdChuDe { get; set; }
        public ChuDe chuDe { get; set; }

        public virtual ICollection<ChiTietBaiGiang> ctbg { get; set; }
        // khi tạo có thể null ctdh
        public BaiGiang()
        {
            ctbg = new HashSet<ChiTietBaiGiang>();
        }
        public virtual ICollection<Resources> resources { get; set; }


    }
}
