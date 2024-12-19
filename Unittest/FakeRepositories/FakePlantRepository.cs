using CORE.Dto;
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

        public Task<IEnumerable<PlantDto>> GetAllAsync()
        {
            var plantDtos = _plants.Select(p => new PlantDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Location = p.Location,
                Water = p.Water,
                Repotting = p.Repotting,
                Toxic = p.Toxic,
                Image = p.Image
            });
            return Task.FromResult(plantDtos.AsEnumerable());
        }

        public Task<PlantDto?> GetByIdAsync(long id)
        {
            var plant = _plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                return Task.FromResult<PlantDto?>(null);
            }

            var plantDto = new PlantDto
            {
                Id = plant.Id,
                Name = plant.Name,
                Description = plant.Description,
                Location = plant.Location,
                Water = plant.Water,
                Repotting = plant.Repotting,
                Toxic = plant.Toxic,
                Image = plant.Image
            };

            return Task.FromResult<PlantDto?>(plantDto);
        }

        public void AddPlant(Plant plant)
        {
            _plants.Add(plant);
        }

        public Task<IEnumerable<IssueDto>> GetPlantIssuesAsync()
        {
            var issues = new List<IssueDto>();
            return Task.FromResult(issues.AsEnumerable());
        }
    }
}
