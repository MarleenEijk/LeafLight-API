using CORE.Dto;

namespace CORE.Interfaces
{
    public interface IPlantRepository
    {
        Task AddAsync(PlantDto plantDto);
        Task<IEnumerable<PlantDto>> GetAllAsync();
        Task<PlantDto?> GetByIdAsync(long id);
        Task<IEnumerable<IssueDto>> GetPlantIssuesAsync();
        Task DeleteAsync(long id); 
    }
}
