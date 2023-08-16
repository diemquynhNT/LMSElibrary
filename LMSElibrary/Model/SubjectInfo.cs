using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class ThongtinMonHoc
    {
        [Key]
        public string IdThongtin { get; set; }
        [Required]
        [MaxLength(100)]
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }

        public string? IdMonHoc { get; set; }
        public MonHoc monHoc { get; set; }

    }
}
