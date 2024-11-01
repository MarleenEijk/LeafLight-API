using CORE.Interfaces;
using CORE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unittest.FakeRepositories
{
    public class FakePlantRepository : IPlantRepository
    {
        private readonly List<Plant> _plants = new();

        public Task<IEnumerable<Plant>> GetAllAsync()
        {
            return Task.FromResult(_plants.AsEnumerable());
        }

        public Task<Plant?> GetByIdAsync(long id)
        {
            var plant = _plants.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(plant);
        }

        public void AddPlant(Plant plant)
        {
            _plants.Add(plant);
        }
    }
}
