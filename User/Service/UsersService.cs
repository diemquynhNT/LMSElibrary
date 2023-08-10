using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.IO;
using System.IO.Pipes;
using System.Text.RegularExpressions;
using UserService.Data;
using UserService.Model;

namespace UserService.Service
{
    public class UsersService : IUsers
    {
        private readonly MyDBContext _context;
        public static IWebHostEnvironment _webHostEnvironment;

        public UsersService(MyDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public  bool ChangePassword(string userId, string newPassword,string oldPassword,string new2Password )
        {
            var user =  _context.users.SingleOrDefault(t=>t.IdUser==userId);
            if (user == null)
            {
                return false;
            }
            if (user.Password != oldPassword)
                return false;
            if (ValidatePassword(newPassword)==false)
                return false;
            else if( newPassword!=new2Password)
                return false;
            else
            {
                user.Password= newPassword;
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

        public async Task CreateUsers(ImageUploadModel us, string idkhoa, string idpos)
        {

            try
            {
                Random rd = new Random();
                var keypos = "";
                if (idpos == "GV")
                    keypos = "GV";
                else if (idpos == "SV")
                    keypos = "SV";
                else keypos = "AD";

                Users users = new Users();
                users.IdUser = keypos + rd.Next(1, 100);
                users.Nameus = us.Nameus;
                users.Email = us.Email;
                users.Numphone = us.Numphone;
                users.Username = us.Username;
                users.Password = us.Password;
                users.Address = us.Address;
                users.IdPos = idpos;
                users.IdKhoa = idkhoa;
                users.Gender = us.Gender;
                //using (var stream = new MemoryStream())
                //    {
                //    if (stream.Length < 2097152)
                //    {
                //        ImageData.CopyTo(stream);
                //        users.ImageUser = stream.ToArray();
                //    }
                //    }

                if (us.Users.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);

                    }
                    using (FileStream fileStream = System.IO.File.Create(path + us.Users.FileName))
                    {
                        us.Users.CopyTo(fileStream);
                        fileStream.Flush();
                        users.ImageUser = us.Users.FileName;

                    }
                }
                _context.Add(users);
                await _context.SaveChangesAsync();
                   
            }
            catch (Exception)
            {
                throw;
            }
           
        }

       

        public void DeleteUsers(string id)
        {
            var us = _context.users.SingleOrDefault(t => t.IdUser == id);
            if (us != null)
            {
                _context.Remove(us);
                _context.SaveChanges();
            }
        }

        

        public async Task<UserModel> EditUsers(UserModel us, string id)
        {
            Users users = _context.users.Where(t => t.IdUser == id).FirstOrDefault();
            users.Nameus = us.Nameus;
            users.Email = us.Email;
            users.Numphone = us.Numphone;
            users.Username = us.Username;
            users.Password = us.Password;
            users.Address = us.Address;
            _context.Add(users);
            await _context.SaveChangesAsync();

            return us;
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

            // Tạo tên tệp duy nhất bằng cách kết hợp thời gian hiện tại và tên tệp gốc
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

        public async Task AddPos(PositionModel pos)
        {
            Position p = new Position();
            p.NamePos = pos.NamePos;
            p.Mota=pos.Mota;
            _context.Add(p);
            await _context.SaveChangesAsync();

        }

        public async Task<PositionModel> EditPos(PositionModel p, string id)
        {
            var position = _context.positions.SingleOrDefault(t => t.IdPos == id);
            if (position == null)
                return null;
            position.Mota = p.Mota;
            position.NamePos = p.NamePos;
            _context.Add(position);
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
    }
    }

