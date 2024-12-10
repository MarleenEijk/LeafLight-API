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
    }
}
