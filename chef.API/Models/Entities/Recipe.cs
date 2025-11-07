namespace chef.API.Models.Entities;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public string Steps { get; set; }
    public int PreparationTimeMinutes { get; set; }
    public int ChefId { get; set; }
}