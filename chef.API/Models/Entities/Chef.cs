namespace chef.API.Models.Entities;

public class Chef
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Specialty { get; set; }
    public string Bio { get; set; }
    public string ProfileImageUrl { get; set; }
    public ICollection<Recipe> Recipes { get; set; }
}