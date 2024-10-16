using Microsoft.AspNetCore.Mvc;
using LeafLight_API.Models;

namespace LeafLight_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private User[] _users = new User[]
        {
            new User { Id = 1, Name = "user1", Emailadress = "user1@mail.com", Password = "Password1"
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }
    }
}
