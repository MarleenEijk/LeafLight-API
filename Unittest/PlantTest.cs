using CORE.Dto;
using CORE.Models;
using CORE.Services;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class PlantTest
    {
        private readonly PlantService _plantService;
        private readonly FakePlantRepository _fakePlantRepository;

        public PlantTest()
        {
            _fakePlantRepository = new FakePlantRepository();
            _plantService = new PlantService(_fakePlantRepository);
        }

        [Fact]
        public async Task GetAllPlantsAsync_ShouldReturnAllPlants()
        {
            var plant1 = new Plant { Id = 1, Name = "Plant1", Description = "Description1", 
                Location = "Location1", Water = "Water1", Repotting = "Repotting1", Toxic = "Toxic1", Image = "Image1" };
            var plant2 = new Plant { Id = 2, Name = "Plant2", Description = "Description2", 
                Location = "Location2", Water = "Water2", Repotting = "Repotting2", Toxic = "Toxic2", Image = "Image2" };
            _fakePlantRepository.AddPlant(plant1);
            _fakePlantRepository.AddPlant(plant2);

            var result = await _plantService.GetAllPlantsAsync();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetPlantByIdAsync_ShouldReturnPlant()
        {
            var plant = new Plant { Id = 1, Name = "Plant1", Description = "Description1", 
                Location = "Location1", Water = "Water1", Repotting = "Repotting1", Toxic = "Toxic1", Image = "Image1" };
            _fakePlantRepository.AddPlant(plant);

            var result = await _plantService.GetPlantByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal("Plant1", result?.Name);
        }

        [Fact]
        public async Task GetAllPlantsAsync_ShouldReturnEmptyList_WhenNoPlantsAdded()
        {
            var result = await _plantService.GetAllPlantsAsync();
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetPlantByIdAsync_ShouldReturnNull_WhenPlantDoesNotExist()
        {
            var result = await _plantService.GetPlantByIdAsync(78689);
            Assert.Null(result);
        }
    }
}
