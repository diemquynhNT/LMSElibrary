using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserService.Model;

namespace UserService.Dto
{
    public class UsersModel
    {
        
        public bool Gender { get; set; }

        public string Nameus { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Numphone { get; set; }
        public string Address { get; set; }

        public string IdPos { get; set; }

        public string? IdClass { get; set; }

        public string? IdKhoa { get; set; }
    }
}
