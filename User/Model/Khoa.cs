using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Model
{
    [Table("Khoa")]
    public class Khoa
    {
        [Key]
        public string IdKhoa { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameKhoa { get; set; }

        public virtual ICollection<Users> users { get; set; }
    }
}
