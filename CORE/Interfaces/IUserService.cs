using System.Collections.Generic;
using System.Threading.Tasks;
using CORE.Dto;

namespace CORE.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
