﻿using Container_App.Model.Users;
using Container_App.Repository.UserRepository;
using Container_App.utilities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Container_App.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserModel>> GetUsers(PagedResult page)
        {
            return await _userRepository.GetUsers(page);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<int> CreateUser(UserModel user)
        {
            return await _userRepository.CreateUser(user);
        }

        public Task<int> UpdateUser(UserModel user)
        {
            return _userRepository.UpdateUser(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

    }
}
