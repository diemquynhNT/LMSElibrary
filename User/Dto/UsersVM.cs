using System.ComponentModel.DataAnnotations;

namespace UserService.Dto
{
    public class UsersVM
    {
        public string IdUser { get; set; }
        public string Nameus { get; set; }
        public bool Gender { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Numphone { get; set; }
        public string Address { get; set; }

        public string IdPos { get; set; }

        public string? IdClass { get; set; }

        public string? IdKhoa { get; set; }
    }
}
