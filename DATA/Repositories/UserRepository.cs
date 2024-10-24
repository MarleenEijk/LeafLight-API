using CORE.Interfaces;
using CORE.Dto;
using Microsoft.EntityFrameworkCore;
using CORE.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

        public async Task UpdateUserAsync(User user)
        {
            var userDto = await _context.user.FindAsync(user.Id);
            if (userDto == null)
            {
                throw new KeyNotFoundException($"User with id: {user.Id} was not found.");
            }

            userDto.Name = user.Name;
            userDto.Emailaddress = user.Emailaddress;
            userDto.Password = user.Password;

            _context.user.Update(userDto);
            await _context.SaveChangesAsync();
        }

        public async Task AddUserAsync(User user)
        {
            var userDto = new UserDto
            {
                Name = user.Name,
                Emailaddress = user.Emailaddress,
                Password = user.Password
            };

            await _context.user.AddAsync(userDto);
            await _context.SaveChangesAsync();

            user.Id = userDto.Id;
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
    }
}
