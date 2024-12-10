using CORE.Dto;

namespace CORE.Interfaces
{
    public interface IPlantRepository
    {
        Task<IEnumerable<PlantDto>> GetAllAsync();
        Task<PlantDto?> GetByIdAsync(long id);
        Task<IEnumerable<IssueDto>> GetPlantIssuesAsync();
    }
}
