using chef.API.DTOs.Chef;
using chef.API.Models.Entities;
using chef.API.Services.ChefService;
using Microsoft.AspNetCore.Mvc;

namespace chef.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChefController : ControllerBase
{
    private readonly IChefService _chefService;

    public ChefController(IChefService chefService)
    {
        _chefService = chefService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var chefs = await _chefService.GetAllAsync();
        return Ok(chefs);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var chef = await _chefService.GetByIdAsync(id);
        if (chef == null)
            return NotFound(new { message = "Chef not found" });
        return Ok(chef);
    }

    // POST: api/chefs
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ChefInDto dto)
    {
        var created = await _chefService.CreateAsync(dto);
        return Ok(created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ChefInDto dto)
    {

        var success = await _chefService.UpdateAsync(id, dto);
        if (!success)
            return NotFound(new { message = "Chef not found" });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _chefService.DeleteAsync(id);
        if (!success)
            return NotFound(new { message = "Chef not found" });

        return NoContent();
    }
}