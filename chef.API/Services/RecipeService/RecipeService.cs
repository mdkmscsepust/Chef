using chef.API.Data;
using chef.API.DTOs.Recipe;
using chef.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace chef.API.Services.RecipeService;

public class RecipeService : IRecipeService
{
    private readonly ApplicationDbContext _context;

    public RecipeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RecipeOutDto>> GetAllAsync()
    {
        var list = await _context.Recipes.ToListAsync();
        return list.Select(recipe => new RecipeOutDto
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients,
            Steps = recipe.Steps,
            PreparationTimeMinutes = recipe.PreparationTimeMinutes,
            ChefId = recipe.ChefId
        });
    }

    public async Task<RecipeOutDto?> GetByIdAsync(int id)
    {
        return (await _context.Recipes.FindAsync(id)) is Recipe chef ? new RecipeOutDto
        {
            Id = chef.Id,
            Title = chef.Title,
            Description = chef.Description,
            Ingredients = chef.Ingredients,
            Steps = chef.Steps,
            PreparationTimeMinutes = chef.PreparationTimeMinutes,
            ChefId = chef.ChefId
        } : null;
    }

    public async Task<bool> CreateAsync(RecipeInDto recipe)
    {

        _context.Recipes.Add(new Recipe
        {
            Title = recipe.Title,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients,
            Steps = recipe.Steps,
            PreparationTimeMinutes = recipe.PreparationTimeMinutes,
            ChefId = recipe.ChefId
        });

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, RecipeInDto updatedRecipe)
    {
        var chef = await _context.Recipes.FindAsync(id);
        if (chef == null) return false;

        chef.Title = updatedRecipe.Title;
        chef.Description = updatedRecipe.Description;
        chef.Ingredients = updatedRecipe.Ingredients;
        chef.Steps = updatedRecipe.Steps;
        chef.PreparationTimeMinutes = updatedRecipe.PreparationTimeMinutes;
        chef.ChefId = updatedRecipe.ChefId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var chef = await _context.Recipes.FindAsync(id);
        if (chef == null) return false;

        _context.Recipes.Remove(chef);
        await _context.SaveChangesAsync();
        return true;
    }
}