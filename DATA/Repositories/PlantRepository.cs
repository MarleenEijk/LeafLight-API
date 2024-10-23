using CORE.Interfaces;
using CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace DATA.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly AppDbContext _context;

        public PlantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Plant>> GetAllAsync()
        {
            var plantDtos = await _context.Plants.ToListAsync();
            return plantDtos.Select(dto => new Plant
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Location = dto.Location,
                Watering = dto.Watering,
                Repotting = dto.Repotting,
                Toxic = dto.Toxic
            });
        }

        public async Task<Plant?> GetByIdAsync(int id)
        {
            var plantDto = await _context.Plants.FindAsync(id);
            if (plantDto == null)
            {
                return null;
            }

            return new Plant
            {
                Id = plantDto.Id,
                Name = plantDto.Name,
                Description = plantDto.Description,
                Location = plantDto.Location,
                Watering = plantDto.Watering,
                Repotting = plantDto.Repotting,
                Toxic = plantDto.Toxic
            };
        }
    }
}
