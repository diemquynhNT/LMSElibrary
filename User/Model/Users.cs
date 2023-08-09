using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Model
{
    [Table("User")]
    public class Users
    {
        [Key]
        public string IdUser { get; set; }
        [Required]
        [MaxLength(100)]

        public string Nameus { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Numphone { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public string IdPos { get; set; }
        [ForeignKey("IdPos")]
        public Position cv { get; set; }

        public string? IdClass { get; set; }
       
        public string? IdKhoa { get; set; }
        [ForeignKey("IdKhoa")]
        public Khoa khoas { get; set; }

        public string? ImageUser { get; set; }




    }
}
