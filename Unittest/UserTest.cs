using CORE.Models;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class UserTest
    {
        private readonly FakeUserRepository _repository;

        public UserTest()
        {
            _repository = new FakeUserRepository();
        }

        [Fact]
        public async Task AddUserAsync_ShouldAddUser()
        {
            var user = new User { Id = 1, Name = "John Doe", Emailaddress = "john@example.com", Password = "password" };
            await _repository.AddUserAsync(user);

            var result = await _repository.GetByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal("John Doe", result?.Name);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllUsers()
        {
            var user1 = new User { Id = 1, Name = "John Doe", Emailaddress = "john@example.com", Password = "password" };
            var user2 = new User { Id = 2, Name = "Jane Doe", Emailaddress = "jane@example.com", Password = "password" };
            await _repository.AddUserAsync(user1);
            await _repository.AddUserAsync(user2);

            var result = await _repository.GetAllAsync();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldUpdateUser()
        {
            var user = new User { Id = 1, Name = "John Doe", Emailaddress = "john@example.com", Password = "password" };
            await _repository.AddUserAsync(user);

            user.Name = "John Smith";
            await _repository.UpdateUserAsync(user);

            var result = await _repository.GetByIdAsync(1);
            Assert.Equal("John Smith", result?.Name);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldRemoveUser()
        {
            var user = new User { Id = 1, Name = "John Doe", Emailaddress = "john@example.com", Password = "password" };
            await _repository.AddUserAsync(user);

            await _repository.DeleteUserAsync(1);

            var result = await _repository.GetByIdAsync(1);
            Assert.Null(result);
        }
    }
}
