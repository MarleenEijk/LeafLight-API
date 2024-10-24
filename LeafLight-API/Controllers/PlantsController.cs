using Microsoft.AspNetCore.Mvc;
using CORE.Models;
using CORE.Interfaces;
using CORE.Services;
using CORE.Dto;

namespace LeafLight_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantsController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantDto>>> GetAllPlantsAsync()
        {
            var plantDtos = await _plantService.GetAllPlantsAsync();
            return Ok(plantDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantDto>> GetPlantById(long id)
        {
            var plantDto = await _plantService.GetPlantByIdAsync(id);
            if (plantDto == null)
            {
                return NotFound();
            }
            return Ok(plantDto);
        }
    }
}
