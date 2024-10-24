using System.Collections.Generic;
using System.Threading.Tasks;
using CORE.Dto;

namespace CORE.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(long id);
        Task<UserDto> AddUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(long id);
    }



}
