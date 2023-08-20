﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserService.Dto;
using UserService.Model;

namespace UserService.Service
{
    public interface IUsers
    {
        public Task<IEnumerable<Users>> GetAllUsers();
        public Task<Users> GetUserByid(string id);

        public Task AddUsersAsync(IFormFile imge,Users us);
        //public Task<UserModel> EditUsers(UserModel us, string id);

        public void DeleteUsers(string id);
        public void DeleteAllUser();

        public Task<string> UploadImage(IFormFile imageFile);
        public FileStream GetImageById(string id);
        public bool ChangePassword(string userId, UserPasswordVM us);
        public bool ValidatePassword(string password);
        public bool IsValidUser(string id);

        public Users LoginUser(string username, string password);
        public string GetToken(Users user);

        //pos
        public Task<IEnumerable<Position>> GetAllPost();
        public Task<Position> GetPosById(string id);
        public Task AddPos(PositionModel pos);
        public Task<PositionModel> EditPos(PositionModel us, string id);
        public void DeletePos(string id);

    }
}
