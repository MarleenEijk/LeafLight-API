using CORE.Dto;
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

        public async Task<IEnumerable<PlantDto>> GetAllAsync()
        {
            var plantDtos = await _context.plant.ToListAsync();
            return plantDtos;
        }

        public async Task<PlantDto?> GetByIdAsync(long id)
        {
            return await _context.plant.FindAsync(id);
        }

        public async Task<IEnumerable<IssueDto>> GetPlantIssuesAsync()
        {
            var result = await (from pi in _context.Set<PlantIssue>()
                                join p in _context.plant on pi.PlantId equals p.Id
                                join i in _context.issue on pi.IssueId equals i.Id
                                select new IssueDto
                                {
                                    Id = i.Id,
                                    Name = i.Name,
                                    Cause = i.Cause,
                                    Solution = i.Solution,
                                    Image = i.Image
                                }).ToListAsync();

            return result;
        }

        public async Task AddAsync(PlantDto plantDto)
        {
            var plant = new Plant
            {
                Name = plantDto.Name,
                Description = plantDto.Description,
                Location = plantDto.Location,
                Water = plantDto.Water,
                Repotting = plantDto.Repotting,
                Toxic = plantDto.Toxic,
                Image = plantDto.Image
            };

            _context.plant.Add(plantDto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var plant = await _context.plant.FindAsync(id);
            if (plant != null)
            {
                _context.plant.Remove(plant);
                await _context.SaveChangesAsync();
            }
        }
    }
}
