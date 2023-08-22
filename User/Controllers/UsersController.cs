using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using UserService.Dto;
using UserService.Model;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers iuser;
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public UsersController(IUsers _iuser,IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            iuser = _iuser;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

       
        [HttpGet("GetImage")]
        public IActionResult GetImageDemo([FromQuery] string id)
        {
            var fileStream = iuser.GetImageById(id);
            if(fileStream!=null)
                return File(fileStream, "image/png");
            return NotFound();
        }

        [HttpGet("Listuser")]
        public Task<IEnumerable<Users>> GetAllUsers()
        {
            var listuserr = iuser.GetAllUsers();
            return listuserr;
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult> GetUserById(string idUser)
        {
            try
            {
                var u = iuser.GetUserByid(idUser);
                if (u == null)
                    return BadRequest("khong tim thay user");
                Users user = await u;
                var userViewModel = _mapper.Map<UsersVM>(user);
                return Ok(userViewModel);
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }
      

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser([FromForm] UsersModel userDto, IFormFile imge)
        {
           
            try
            {
                bool checkpass = iuser.ValidatePassword(userDto.Password);
                if(!checkpass)
                {
                    return BadRequest("password khong hop le");
                }
                var userModel = _mapper.Map<Users>(userDto);
                await iuser.AddUsers(imge, userModel);
                return Ok("da tao user");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("ChangePassword")]
        public IActionResult ChangePasswordUser(string userId, [FromForm] UserPasswordVM us)
        {
            try
            {
                bool check = iuser.ChangePassword(userId, us);
                if (!check)
                    return BadRequest("loi");
                return Ok("Da doi password");
                
            }
            catch
            {
                return BadRequest("khon hop le");
            }
        }
        [HttpPut("UploadUser")]
        public async Task<IActionResult> UploadUser(string id,[FromBody]UsersModel u)
        {
            var user = await iuser.GetUserByid(id);
            if (user == null)
            {
                return NotFound("Khong tim thay user");
            }
            _mapper.Map(u, user);
            await iuser.UpdateUser(user);
            return Ok("thanh cong");
        }

      
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> deleteUser(string id)
        {
            var result = await iuser.DeleteUser(id);
            if (!result)
                return NotFound();
            return Ok("xoa thanh cong");
        }

        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAllUser()
        {
            try
            {
                iuser.DeleteAllUser();

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

       


        
    }
}
