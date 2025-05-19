namespace RecipeDatabase.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public string? RecipeInstructions { get; set; }
    }
}
