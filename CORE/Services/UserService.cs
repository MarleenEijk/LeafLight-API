using CORE.Interfaces;
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
                Emailadress = user.Emailadress,
                Password = user.Password
            }).ToList();
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
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
                Emailadress = user.Emailadress,
                Password = user.Password
            };
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Emailadress = userDto.Emailadress,
                Password = userDto.Password
            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Emailadress = userDto.Emailadress,
                Password = userDto.Password
            };

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
