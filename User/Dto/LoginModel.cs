using System.ComponentModel.DataAnnotations;

namespace UserService.Dto
{

    public enum RoleUsers
    {
        //set tình trạng theo số
        Admin = 1, GV = 2, SV = 3,
    }
    public class LoginModel
    {
       
        public string Username { get; set; }
  
        public string Password { get; set; }


        public RoleUsers RoleUsers { get; set; }
    }
}
