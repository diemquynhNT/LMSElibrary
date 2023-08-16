using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class DanhsachLop
    {
        [Key]
        public string IdDSLop { get; set; }

        public string? IdLop { get; set; }
        public Lop lop { get; set; }
        public string? IdStudent { get; set; }
    }
}
