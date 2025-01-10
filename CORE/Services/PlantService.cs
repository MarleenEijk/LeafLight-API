using CORE.Dto;
using CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.Services
{
    public class PlantService
    {
        private readonly IPlantRepository _plantRepository;

        public PlantService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository ?? throw new ArgumentNullException(nameof(plantRepository));
        }

        public async Task<IEnumerable<PlantDto>> GetAllPlantsAsync()
        {
            var plants = await _plantRepository.GetAllAsync();
            return plants;
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

        public async Task CreatePlantAsync(PlantDto plantDto)
        {
            if (plantDto == null)
            {
                throw new ArgumentNullException(nameof(plantDto));
            }

            await _plantRepository.AddAsync(plantDto);
        }

        public async Task DeletePlantAsync(long id)
        {
            await _plantRepository.DeleteAsync(id);
        }
    }
}
