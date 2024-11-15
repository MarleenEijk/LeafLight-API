using CORE.Dto;
using CORE.Models;
using CORE.Services;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class UserTest
    {
        private readonly UserService _userService;
        private readonly FakeUserRepository _fakeUserRepository;

        public UserTest()
        {
            _fakeUserRepository = new FakeUserRepository();
            _userService = new UserService(_fakeUserRepository);
        }

        [Fact]
        public async Task AddUserAsync_ShouldAddUser()
        {
            var userDto = new UserDto { Id = 1, Name = "John Doe", Emailaddress = "john@example.com", Password = "password" };

            await _userService.AddUserAsync(userDto);

            var result = await _userService.GetUserByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal("John Doe", result?.Name);
        }

        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnAllUsers()
        {
            var userDto1 = new UserDto { Id = 1, Name = "John Doe", Emailaddress = "john@example.com", Password = "password" };
            var userDto2 = new UserDto { Id = 2, Name = "Jane Doe", Emailaddress = "jane@example.com", Password = "password" };

            await _userService.AddUserAsync(userDto1);
            await _userService.AddUserAsync(userDto2);

            var result = await _userService.GetAllUsersAsync();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldUpdateUser()
        {
            var userDto = new UserDto { Id = 1, Name = "John Doe", Emailaddress = "john@example.com", Password = "password" };
            await _userService.AddUserAsync(userDto);

            userDto.Name = "John Smith";
            await _userService.UpdateUserAsync(userDto);

            var result = await _userService.GetUserByIdAsync(1);
            Assert.Equal("John Smith", result?.Name);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldRemoveUser()
        {
            var userDto = new UserDto { Id = 1, Name = "John Doe", Emailaddress = "john@example.com", Password = "password" };
            await _userService.AddUserAsync(userDto);

            await _userService.DeleteUserAsync(1);

            var result = await _userService.GetUserByIdAsync(1);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnEmptyList_WhenNoUsersAdded()
        {
            var result = await _userService.GetAllUsersAsync();
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnNull_WhenUserDoesNotExist()
        {
            var result = await _userService.GetUserByIdAsync(999);
            Assert.Null(result);
        }
    }
}
