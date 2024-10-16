using LeafLight_API.Models;

namespace LeafLight_API.Repositories
{
    public interface IPlantRepository
    {
        Task<IEnumerable<Plant>> GetAllasync();
        Task<Plant> GetById(int id);
    }
}
