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

        //[HttpGet("UpLoadImage")]
        //public IActionResult GetImage(string id)
        //{

        //    byte[] imageBytes = iuser.GetImage(id);
        //    string mimeType = "image/png";
        //    return File(imageBytes, mimeType);
        //}


        [HttpGet("Listuser")]
        public Task<IEnumerable<Users>> GetAllUsers()
        {
            var listuserr = iuser.GetAllUsers();
            return listuserr;
        }

      
        [HttpGet("filterlist")]
        public Task<Users> GetUserById (string Id)
        {
            var u=iuser.GetUserByid(Id);
            return u;
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
                iuser.AddUsersAsync(imge, userModel);
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
        //[HttpPut("EditUser")]
        //public IActionResult EditUser(UserModel users,string id)
        //{
        //    bool check = iuser.IsValidUser(id);
        //    if (!check)
        //    {
        //        return BadRequest("Thông tin người dùng không hợp lệ");
        //    }

        //    iuser.EditUsers(users, id);

        //    return Ok("Người dùng đã được tải lên thành công");
        //}


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
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

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            try
            {
                var user = iuser.LoginUser(model.Username, model.Password);
                

                if (user == null)
                {
                    return Ok(new
                    {
                        Success = false,
                        Message = "Invalid user/pass"
                    });
                }
                return Ok(new
                {
                    Success = true,
                    Message = "Authentication success",
                    Data = iuser.GetToken(user)
                }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        //[HttpPost("upload-image")]
        //public async Task<IActionResult> UploadImage([FromForm] IFormFile imageFile)
        //{
        //    if (imageFile == null)
        //    {
        //        return BadRequest("No image file sent");
        //    }

        //    try
        //    {
        //        string imageUrl = await iuser.UploadImage(imageFile);
        //        return Ok(imageUrl);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "An error occurred while uploading the image");
        //    }
        //}
        //[HttpPost]
        //public async Task<string> Post([FromForm] ImagesUpload imagesUpload)
        //{
        //    try
        //    {
        //        if(imagesUpload.Users.Length > 0)
        //        {
        //            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
        //            if(!Directory.Exists(path))
        //            {
        //                Directory.CreateDirectory(path);

        //            }
        //            using(FileStream fileStream=System.IO.File.Create(path+ imagesUpload.files.FileName))
        //            {
        //                imagesUpload.files.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return "Upload done";

        //            }    
        //        }
        //        else
        //        {
        //            return "Failed";
        //        }    
        //    }
        //    catch (Exception ex)
        //    {
        //       return "Failed";
        //    }
        //}


        //[HttpGet("LayHinh")]
        //public IActionResult Get([FromRoute] string imgname)
        //{
        //    try
        //    {
        //        string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
        //        var filePath = path + imgname + ".png";
        //        if (System.IO.File.Exists(filePath))
        //        {
        //            byte[] b = System.IO.File.ReadAllBytes("filePath");
        //            return File(b, "image/png");
        //        }
        //        return NotFound();
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest("Loi");
        //    }

        //}
    }
}
