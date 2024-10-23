using CORE.Models;

namespace CORE.Interfaces
{
    public interface IPlantRepository
    {
        Task<IEnumerable<Plant>> GetAllAsync();
        Task<Plant?> GetByIdAsync(int id);
    }
}
