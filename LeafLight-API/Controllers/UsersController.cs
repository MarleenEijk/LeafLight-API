using Microsoft.AspNetCore.Mvc;
using CORE.Dto;
using CORE.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeafLight_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var userDtos = await _userService.GetAllUsersAsync();
            return Ok(userDtos);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto)
        {
            var createdUser = await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(long id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(long id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(long id, UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }
            var updatedUser = await _userService.UpdateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = updatedUser.Id }, updatedUser);
        }

        [HttpGet("exists")]
        public async Task<ActionResult<bool>> EmailExists([FromQuery] string email)
        {
            var exists = await _userService.EmailExistsAsync(email);
            return Ok(exists);
        }

    }
}
