using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class Resources
    {
        [Key]
        public string IdResources { get; set; }
        [Required]
        [MaxLength(100)]
        public string FormatFile { get; set; }
        public string? Mota { get; set; }
        public string? NguoiDuyet { get; set; }
        public string? FileURL { get; set; }
        public bool TinhTrangDuyet { get; set; }
        public string? NoteRes { get; set; }
        public DateTime NgayGui { get; set; }

        public string? IdBaiGiang { get; set; }
        public BaiGiang baiGiang { get; set; }

    }
}
