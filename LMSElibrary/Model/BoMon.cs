using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SubjectService.Model
{
    public class BoMon
    {
        [Key]
        public string IdBoMon { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenBoMon { get; set; }

        public virtual ICollection<MonHoc> MonHocs { get; set; }
    }
}
