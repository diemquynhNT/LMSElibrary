using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserService.Model;

namespace UserService.Service
{
    public interface IUsers
    {
        public Task<IEnumerable<Users>> GetAllUsers();
        public Task<Users> GetUserByid(string id);
        public Task<UserModel> CreateUsers(UserModel us, string idkhoa, string idpos);
        public Task<UserModel> EditUsers(UserModel us, string id);
        public void DeleteUsers(string id);



    }
}
