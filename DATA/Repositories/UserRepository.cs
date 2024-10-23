using CORE.Interfaces;
using CORE.Dto;
using Microsoft.EntityFrameworkCore;
using CORE.Models;

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
            var userDtos = await _context.Users.ToListAsync();
            return userDtos.Select(dto => new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Emailadress = dto.Emailadress,
                Password = dto.Password
            });
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var userDto = await _context.Users.FindAsync(id);
            if (userDto == null)
            {
                return null;
            }

            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Emailadress = userDto.Emailadress,
                Password = userDto.Password
            };
        }

        public async Task UpdateUserAsync(User user)
        {
            var userDto = await _context.Users.FindAsync(user.Id);
            if (userDto == null)
            {
                throw new KeyNotFoundException($"User with id: {user.Id} was not found.");
            }

            userDto.Name = user.Name;
            userDto.Emailadress = user.Emailadress;
            userDto.Password = user.Password;

            _context.Users.Update(userDto);
            await _context.SaveChangesAsync();
        }

        public async Task AddUserAsync(User user)
        {
            var userDto = new UserDto
            {
                Name = user.Name,
                Emailadress = user.Emailadress,
                Password = user.Password
            };

            await _context.Users.AddAsync(userDto);
            await _context.SaveChangesAsync();

            user.Id = userDto.Id;
        }

        public async Task DeleteUserAsync(int id)
        {
            var userDto = await _context.Users.FindAsync(id);
            if (userDto == null)
            {
                throw new KeyNotFoundException($"User with id: {id} was not found.");
            }
            _context.Users.Remove(userDto);
            await _context.SaveChangesAsync();
        }
    }
}
