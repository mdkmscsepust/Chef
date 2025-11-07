using chef.API.Data;
using chef.API.DTOs.Review;
using chef.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace chef.API.Services.ReviewService;

public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _context;
    public ReviewService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ReviewOutDto>> GetAllAsync()
    {
        var list = await _context.Reviews.ToListAsync();
        return list.Select(chef => new ReviewOutDto
        {
            Rating = chef.Rating,
            Comment = chef.Comment,
            CreatedAt = chef.CreatedAt
        });
    }

    public async Task<ReviewOutDto?> GetByIdAsync(int id)
    {
        return (await _context.Reviews.FindAsync(id)) is Review chef ? new ReviewOutDto
        {
            Rating = chef.Rating,
            Comment = chef.Comment,
            CreatedAt = chef.CreatedAt
        } : null;
    }

    public async Task<bool> CreateAsync(ReviewInDto reviewInDto)
    {

        _context.Reviews.Add(new Review
        {
            RecipeId = reviewInDto.RecipeId,
            UserId = reviewInDto.UserId,    
            Rating = reviewInDto.Rating,
            Comment = reviewInDto.Comment,
            CreatedAt = reviewInDto.CreatedAt
        });
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, ReviewInDto updatedChef)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null) return false;
        
        review.RecipeId = updatedChef.RecipeId;
        review.UserId = updatedChef.UserId;
        review.Rating = updatedChef.Rating;
        review.Comment = updatedChef.Comment;
        review.CreatedAt = updatedChef.CreatedAt;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var chef = await _context.Chefs.FindAsync(id);
        if (chef == null) return false;

        _context.Chefs.Remove(chef);
        await _context.SaveChangesAsync();
        return true;
    }
}