using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public UsersController(IUsers _iuser,IWebHostEnvironment webHostEnvironment)
        {
            iuser = _iuser;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<string> Post([FromForm] ImagesUpload imagesUpload)
        {
            try
            {
                if(imagesUpload.files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);

                    }
                    using(FileStream fileStream=System.IO.File.Create(path+ imagesUpload.files.FileName))
                    {
                        imagesUpload.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Upload done";

                    }    
                }
                else
                {
                    return "Failed";
                }    
            }
            catch (Exception ex)
            {
               return "Failed";
            }
        }

        [HttpGet]
        public IActionResult getimg([FromRoute] string imgname)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + imgname + ".png";
            if (System.IO.File.Exists(filePath))
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);
                string mimeType = "image/png";
                return File(imageBytes, mimeType);

            }
            return BadRequest();
           

        }
        [HttpGet]
        public IActionResult GetImage(string id)
        {

            byte[] imageBytes = iuser.GetImage(id);
            string mimeType = "image/png";
            return File(imageBytes, mimeType);
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
            var u=iuser.GetUserByid(Id);
            return u;
        }

        [HttpPost("PostUser")]
        public async Task<ActionResult> AddUser([FromForm] ImageUploadModel fileDetails,string idkhoa, string idpos)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                UserModel us= new UserModel();
                await iuser.CreateUsers(fileDetails,idkhoa,idpos,fileDetails.Users);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }



        //[HttpPut("{id}")]
        //public IActionResult UploadUser([FromBody] UserModel users,string id)
        //{

        //    if (!IsValidUser(users))
        //    {
        //        return BadRequest("Thông tin người dùng không hợp lệ");
        //    }

        //   iuser.EditUsers(users,id);

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

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile imageFile)
        {
            if (imageFile == null)
            {
                return BadRequest("No image file sent");
            }

            try
            {
                string imageUrl = await iuser.UploadImage(imageFile);
                return Ok(imageUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while uploading the image");
            }
        }
    }
}
