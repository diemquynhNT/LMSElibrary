using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Model
{
    [Table("Position")]
    public class Position
    {
        [Key]
        public string IdPos { get; set; }
        [Required]
        [MaxLength(100)]
        public string NamePos { get; set; }
        public string Mota { get; set; }

        public virtual ICollection<Users> users { get; set; }
    }
}
