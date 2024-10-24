using CORE.Dto;
using CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.Services
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;

        public PlantService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository ?? throw new ArgumentNullException(nameof(plantRepository));
        }

        public async Task<IEnumerable<PlantDto>> GetAllPlantsAsync()
        {
            var plants = await _plantRepository.GetAllAsync();
            return plants.Select(plant => new PlantDto
            {
                Id = plant.Id,
                Name = plant.Name,
                Description = plant.Description,
                Location = plant.Location,
                Water = plant.Water,
                Repotting = plant.Repotting,
                Toxic = plant.Toxic,
                Image = plant.Image
            }).ToList();
        }

        public async Task<PlantDto?> GetPlantByIdAsync(long id)
        {
            var plant = await _plantRepository.GetByIdAsync(id);
            if (plant == null)
            {
                return null;
            }

            return new PlantDto
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
        }
    }
}
