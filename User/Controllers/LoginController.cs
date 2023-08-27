using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Dto;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsers iuser;
        public LoginController(IUsers _iuser)
        {
            iuser = _iuser;
        }

        [HttpPost("Login")]
        public IActionResult Validate([FromForm]LoginModel model)
        {
            try
            {
                var user = iuser.LoginUser(model);
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
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
