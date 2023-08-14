using System.ComponentModel.DataAnnotations;

namespace UserService.Model
{

    public enum RoleUsers
    {
        //set tình trạng theo số
        Admin=1,GV=2,SV=3,    
    }
    public class LoginModel
    {
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

      
        public RoleUsers RoleUsers { get; set; }
    }
}
