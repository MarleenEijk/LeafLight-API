using Microsoft.AspNetCore.Mvc;
using CORE.Interfaces;
using CORE.Dto;
using CORE.Services;

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
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
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
            await _userService.UpdateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }
    }
}

