
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using UserService.Data;
using UserService.Dto;
using UserService.Model;

namespace UserService.Service
{
    public class UsersService : IUsers
    {
        private readonly MyDBContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly AppSettings _appSettings;

        public UsersService(MyDBContext context, IWebHostEnvironment webHostEnvironment, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _appSettings = optionsMonitor.CurrentValue;
        }

        public  bool ChangePassword(string userId, UserPasswordVM us)
        {
            var user =  _context.users.SingleOrDefault(t=>t.IdUser==userId);
            if (user == null)
            {
                return false;
            }
            if (user.Password != us.oldPassword)
                return false;
            if (ValidatePassword(us.newPassword1) ==false)
                return false;
            else if(us.newPassword1!=us.newPassword2)
                return false;
            else
            {
                user.Password= us.newPassword1;
                _context.SaveChanges();
                return true;
            }
        }
        public bool ValidatePassword(string password)
        {
            string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,}$";
            bool isValid = Regex.IsMatch(password, passwordRegex);
            return isValid;
        }


        public async Task<Users> UpdateUser(Users u)
        {
            _context.users.Update(u);
            await _context.SaveChangesAsync();
            return u;
        }



        public async Task<bool> DeleteUser(string id)
        {
            var u = await _context.users.FindAsync(id);
            if (u == null)
                return false;

            _context.users.Remove(u);
            await _context.SaveChangesAsync();

            return true;
        }





        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _context.users.ToListAsync();
        }

        public FileStream GetImageById(string id)
        {
            Users users=_context.users.SingleOrDefault(t=>t.IdUser== id);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            var filePath = Path.Combine(path, users.ImageUser);
            if (System.IO.File.Exists(filePath))
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return fileStream;
            }
            return null;

        }

        public async Task<Users> GetUserByid(string id)
        {
            return await _context.users.Where(x => x.IdUser == id).FirstOrDefaultAsync();
        }

        public async Task<string> UploadImage(IFormFile imageFile)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "images");
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            var uniqueFileName = DateTime.Now.Ticks + "_" + imageFile.FileName;

            var filePath = Path.Combine(imagePath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return filePath;
        }

        public bool IsValidUser(string id)
        {
           Users users=_context.users.SingleOrDefault(t=>t.IdUser == id);
            if (users == null)
                return false;
            return true;
        }

       
        //pos
        public async Task<IEnumerable<Position>> GetAllPost()
        {
            return await _context.positions.ToListAsync();
        }

        public async Task<Position> GetPosById(string id)
        {
            return await _context.positions.Where(x => x.IdPos == id).FirstOrDefaultAsync();
        }

        public async Task<Position> AddPos(Position pos)
        {
            _context.Add(pos);
            await _context.SaveChangesAsync();
            return pos;

        }

        public async Task<Position> EditPos(Position p)
        {
            _context.positions.Update(p);
            await _context.SaveChangesAsync();
            return p;
           

        }

        public void DeletePos(string id)
        {
            var pos = _context.positions.SingleOrDefault(t => t.IdPos == id);
            if (pos != null)
            {
                _context.Remove(pos);
                _context.SaveChanges();
            }
            
        }

        public Users LoginUser(string username, string password)
        {
            Users user = _context.users.SingleOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
                return null;
            return user;
        }

        private string GenerateToken(Users users)
        {
            var jwtToken = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                //đặc trưng người dùng
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,users.Nameus),
                    new Claim(ClaimTypes.Email, users.Email),
                    new Claim("UserName", users.Username),
                    //new Claim("Id", users.IdUser),

                    //roles

                   // new Claim("TokenId", Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)


            };

            var token = jwtToken.CreateToken(tokenDescription);
            //trả vê fchuoixo
            return jwtToken.WriteToken(token);

        }

        public async Task<Users> AddUsers(IFormFile imge, Users us)
        {
            Random rd = new Random();
            var keypos = "";
            if (us.IdPos == "GV")
                keypos = "GV";
            else if (us.IdPos == "SV")
                keypos = "SV";
            else keypos = "AD";
            us.IdUser = keypos+rd.Next(1,9)+ rd.Next(10, 99);
            if (imge.Length > 0)
            {
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }
                using (FileStream fileStream = System.IO.File.Create(path + imge.FileName))
                {
                    imge.CopyTo(fileStream);
                    fileStream.Flush();
                    us.ImageUser = imge.FileName;

                }
            }
            _context.Add(us);
            await _context.SaveChangesAsync();
            return us;
        }

        public void DeleteAllUser()
        {
            List<Users> listuser = _context.users.ToList();
            foreach (var user in listuser)
            {
                _context.Remove(user);
            }
            _context.SaveChangesAsync().Wait();
            
        }

        public string GetToken(Users user)
        {
            var token = GenerateToken(user);
            return token;
        }

       
    }
    }

