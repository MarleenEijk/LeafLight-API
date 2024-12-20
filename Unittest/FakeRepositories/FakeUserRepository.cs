﻿using CORE.Dto;
using CORE.Interfaces;
using CORE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unittest.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult(_users.AsEnumerable());
        }

        public Task<User?> GetByIdAsync(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public Task AddUserAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        public Task UpdateUserAsync(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with id: {user.Id} was not found.");
            }

            existingUser.Name = user.Name;
            existingUser.Emailaddress = user.Emailaddress;
            existingUser.Password = user.Password;
            return Task.CompletedTask;
        }

        public Task DeleteUserAsync(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id: {id} was not found.");
            }

            _users.Remove(user);
            return Task.CompletedTask;
        }

        public Task<bool> EmailExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
