using LeafLight_API.Models;

namespace LeafLight_API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllasync();
        Task<User> GetById(int id);
        Task AddUserASync(User user);
        Task UpdateUserASync(User user);
        Task DeleteUserASync(int id);

    }
}
