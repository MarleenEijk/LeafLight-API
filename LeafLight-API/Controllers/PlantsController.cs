using Microsoft.AspNetCore.Mvc;
using LeafLight_API.Models;

namespace LeafLight_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private Plant[] _plants = new Plant[]
        {
            new Plant { Id = 1, Name = "Plant 1"
                ,Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum" 
                ,Location = "Sun"
                ,Watering = "Once a week"
                ,Repotting = "Once every two years"
                ,Toxic = "Yes, for animals"
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Plant>> GetPlants()
        {
            return Ok(_plants);
        }
    }
}
