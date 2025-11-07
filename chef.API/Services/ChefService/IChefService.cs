using chef.API.DTOs.Chef;
using chef.API.Models.Entities;

namespace chef.API.Services.ChefService;

public interface IChefService
{
    Task<IEnumerable<ChefOutDto>> GetAllAsync();
    Task<ChefOutDto?> GetByIdAsync(int id);
    Task<bool> CreateAsync(ChefInDto chef);
    Task<bool> UpdateAsync(int id, ChefInDto updatedChef);
    Task<bool> DeleteAsync(int id);
}