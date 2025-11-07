using chef.API.DTOs.Review;
using chef.API.Services.ReviewService;
using Microsoft.AspNetCore.Mvc;

namespace chef.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chefs = await _reviewService.GetAllAsync();
            return Ok(chefs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var chef = await _reviewService.GetByIdAsync(id);
            if (chef == null)
                return NotFound(new { message = "Chef not found" });
            return Ok(chef);
        }

        // POST: api/chefs
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewInDto dto)
        {
            var created = await _reviewService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { created });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReviewInDto dto)
        {

            var success = await _reviewService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new { message = "Chef not found" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _reviewService.DeleteAsync(id);
            if (!success)
                return NotFound(new { message = "Chef not found" });

            return NoContent();
        }
    }
}