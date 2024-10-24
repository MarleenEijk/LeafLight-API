using CORE.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface IPlantService
    {
        Task<IEnumerable<PlantDto>> GetAllPlantsAsync();
        Task<PlantDto?> GetPlantByIdAsync(int id);
    }
}
