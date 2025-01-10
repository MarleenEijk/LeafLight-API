using Microsoft.AspNetCore.Mvc;
using CORE.Services;
using CORE.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeafLight_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly PlantService _plantService;

        public PlantsController(PlantService plantService)
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

        [HttpPost]
        public async Task<ActionResult> CreatePlantAsync([FromBody] PlantDto plantDto)
        {
            if (plantDto == null)
            {
                return BadRequest("Plant data is required.");
            }

            await _plantService.CreatePlantAsync(plantDto);
            return CreatedAtAction(nameof(GetPlantById), new { id = plantDto.Id }, plantDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlantAsync(long id)
        {
            await _plantService.DeletePlantAsync(id);
            return NoContent();
        }
    }
}
