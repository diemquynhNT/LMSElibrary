using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using UserService.Data;
using UserService.Model;

namespace UserService.Service
{
    public class UsersService : IUsers
    {
        private readonly MyDBContext _context;

        public UsersService(MyDBContext context)
        {
            _context = context;
        }

        public async Task<UserModel> CreateUsers(UserModel us, string idkhoa, string idpos)
        {
            Random rd = new Random();
            var keypos = "";
            if (idpos == "GV")
                keypos = "GV";
            else if (idpos == "SV")
                keypos = "SV";
            else keypos = "AD";

            Users users = new Users();
            users.IdUser = keypos + rd.Next(1,100);
            users.Nameus = us.Nameus;
            users.Email = us.Email;
            users.Numphone = us.Numphone;
            users.Username = us.Username;
            users.Password = us.Password;
            users.Address = us.Address;
            users.IdPos = idpos;
            users.IdKhoa = idkhoa;
            _context.Add(users);
            await _context.SaveChangesAsync();

            return us;
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

        public async Task<Users> GetUserByid(string id)
        {
            return await _context.users.Where(x => x.IdUser == id).FirstOrDefaultAsync();
        }

     
    }
}
