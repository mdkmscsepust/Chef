using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chef.API.DTOs.Recipe
{
    public class RecipeOutDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public int PreparationTimeMinutes { get; set; }
        public int ChefId { get; set; }
    }
}