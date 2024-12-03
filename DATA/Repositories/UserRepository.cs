using CORE.Interfaces;
using CORE.Models;
using CORE.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var userDtos = await _context.user.ToListAsync();
            return userDtos.Select(dto => new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Emailaddress = dto.Emailaddress,
                Password = dto.Password
            });
        }

        public async Task<User?> GetByIdAsync(long id)
        {
            var userDto = await _context.user.FindAsync(id);
            if (userDto == null)
            {
                return null;
            }

            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Emailaddress = userDto.Emailaddress,
                Password = userDto.Password
            };
        }

        public async Task AddUserAsync(User user)
        {
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Emailaddress = user.Emailaddress,
                Password = user.Password
            };

            await _context.user.AddAsync(userDto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUserDto = await _context.user.FindAsync(user.Id);
            if (existingUserDto == null)
            {
                throw new KeyNotFoundException($"User with id: {user.Id} was not found.");
            }

            existingUserDto.Name = user.Name;
            existingUserDto.Emailaddress = user.Emailaddress;
            existingUserDto.Password = user.Password;

            _context.user.Update(existingUserDto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(long id)
        {
            var userDto = await _context.user.FindAsync(id);
            if (userDto == null)
            {
                throw new KeyNotFoundException($"User with id: {id} was not found.");
            }

            _context.user.Remove(userDto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.user.AnyAsync(u => u.Emailaddress == email);
        }

    }
}
