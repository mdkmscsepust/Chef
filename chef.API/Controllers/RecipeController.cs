using chef.API.DTOs.Recipe;
using chef.API.Services.RecipeService;
using Microsoft.AspNetCore.Mvc;

namespace chef.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chefs = await _recipeService.GetAllAsync();
            return Ok(chefs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var chef = await _recipeService.GetByIdAsync(id);
            if (chef == null)
                return NotFound(new { message = "Chef not found" });
            return Ok(chef);
        }

        // POST: api/chefs
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RecipeInDto dto)
        {
            var created = await _recipeService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { created });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RecipeInDto dto)
        {

            var success = await _recipeService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new { message = "Chef not found" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _recipeService.DeleteAsync(id);
            if (!success)
                return NotFound(new { message = "Chef not found" });

            return NoContent();
        }
    }
}