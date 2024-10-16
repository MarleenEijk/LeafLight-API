using LeafLight_API.Models;

namespace LeafLight_API.Repositories
{
    public interface IPlantRepository
    {
        Task<IEnumerable<Plant>> GetAllAsync();
        Task<Plant?> GetByIdAsync(int id);
    }
}
