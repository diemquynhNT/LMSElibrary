using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectService.Model
{
    public class ChuDe
    {
        [Key]
        public string IdChuDe { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? IdMonHoc { get; set; }
        public MonHoc monHoc { get; set; }

        public virtual ICollection<BaiGiang> documents { get; set; }

    }
}
