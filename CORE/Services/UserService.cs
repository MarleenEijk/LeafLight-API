﻿using CORE.Interfaces;
using CORE.Dto;
using CORE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Emailaddress = user.Emailaddress,
                Password = user.Password
            }).ToList();
        }

        public async Task<UserDto?> GetUserByIdAsync(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Emailaddress = user.Emailaddress,
                Password = user.Password
            };
        }

        public async Task<UserDto> AddUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Emailaddress = userDto.Emailaddress,
                Password = userDto.Password
            };

            await _userRepository.AddUserAsync(user);

            userDto.Id = user.Id;

            return userDto;
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Emailaddress = userDto.Emailaddress,
                Password = userDto.Password
            };

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(long id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}

