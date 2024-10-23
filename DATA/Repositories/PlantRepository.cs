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
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant?> GetByIdAsync(int id)
        {
            return await _context.Plants.FindAsync(id);
        }
    }
}
