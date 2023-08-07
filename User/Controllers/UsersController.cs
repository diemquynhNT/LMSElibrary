using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Model;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers iuser;

        public UsersController(IUsers _iuser)
        {
            iuser = _iuser;
        }

        [HttpGet("listuser")]
        public Task<IEnumerable<Users>> GetAllUsers()
        {
            var listuserr = iuser.GetAllUsers();
            return listuserr;
        }
        [HttpGet("filterlist")]
        public Task<Users> GetUserById (string Id)
        {
            return iuser.GetUserByid(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Users>> AddUser(UserModel user, string idkhoa, string idpos)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var addedUser = await iuser.CreateUsers(user,idkhoa,idpos);

            return Ok(addedUser);
        }
        [HttpPut("{id}")]
        public IActionResult UploadUser([FromBody] UserModel users,string id)
        {
            
            if (!IsValidUser(users))
            {
                return BadRequest("Thông tin người dùng không hợp lệ");
            }
            
           iuser.EditUsers(users,id);

            return Ok("Người dùng đã được tải lên thành công");
        }

        private bool IsValidUser(UserModel users)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHoangHoa(string id)
        {
            try
            {
                iuser.DeleteUsers(id);
                
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
