using LeafLight_API.Data;
using LeafLight_API.Models;
using Microsoft.EntityFrameworkCore;


namespace LeafLight_API.Repositories
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
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }


        public async Task AddUserAsync(User user)
        {
           await _context.Users.AddAsync(user);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id: {id} was not found.");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
