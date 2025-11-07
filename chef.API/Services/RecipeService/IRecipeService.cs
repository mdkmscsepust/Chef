using chef.API.DTOs.Recipe;

namespace chef.API.Services.RecipeService;

public interface IRecipeService
{
    Task<IEnumerable<RecipeOutDto>> GetAllAsync();
    Task<RecipeOutDto?> GetByIdAsync(int id);
    Task<bool> CreateAsync(RecipeInDto recipeInDto);
    Task<bool> UpdateAsync(int id, RecipeInDto recipeInDto);
    Task<bool> DeleteAsync(int id);
}