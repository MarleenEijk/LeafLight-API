using CORE.Models;

namespace CORE.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(long id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(long id);
        Task<bool> EmailExistsAsync(string email);
        Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
