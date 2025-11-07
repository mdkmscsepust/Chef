using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chef.API.DTOs.Review
{
    public class ReviewInDto
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}