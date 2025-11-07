using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chef.API.DTOs.Review;

namespace chef.API.Services.ReviewService
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewOutDto>> GetAllAsync();
        Task<ReviewOutDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(ReviewInDto chef);
        Task<bool> UpdateAsync(int id, ReviewInDto updatedChef);
        Task<bool> DeleteAsync(int id);
    }
}