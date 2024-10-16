using Microsoft.AspNetCore.Mvc;
using LeafLight_API.Models;
using LeafLight_API.Repositories;

namespace LeafLight_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            await _userRepository.AddUserAsync(user);
            return Created();
        }
    }
}
