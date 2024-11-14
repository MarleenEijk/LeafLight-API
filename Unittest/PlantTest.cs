using CORE.Models;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class PlantTest
    {
        private readonly FakePlantRepository _repository;

        public PlantTest()
        {
            _repository = new FakePlantRepository();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllPlants()
        {
            var plant1 = new Plant { Id = 1, Name = "Plant1", Description = "Description1", Location = "Location1", Water = "Water1", Repotting = "Repotting1", Toxic = "Toxic1", Image = "Image1" };
            var plant2 = new Plant { Id = 2, Name = "Plant2", Description = "Description2", Location = "Location2", Water = "Water2", Repotting = "Repotting2", Toxic = "Toxic2", Image = "Image2" };
            _repository.AddPlant(plant1);
            _repository.AddPlant(plant2);

            var result = await _repository.GetAllAsync();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPlant()
        {
            var plant = new Plant { Id = 1, Name = "Plant1", Description = "Description1", Location = "Location1", Water = "Water1", Repotting = "Repotting1", Toxic = "Toxic1", Image = "Image1" };
            _repository.AddPlant(plant);

            var result = await _repository.GetByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal("Plant1", result?.Name);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoPlantsAdded()
        {
            var result = await _repository.GetAllAsync();
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenPlantDoesNotExist()
        {
            var result = await _repository.GetByIdAsync(999);
            Assert.Null(result);
        }
    }
}
