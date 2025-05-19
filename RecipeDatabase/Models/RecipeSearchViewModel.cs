using Microsoft.AspNetCore.Mvc.Rendering;
namespace RecipeDatabase.Models
{
    public class RecipeSearchViewModel
    {
        public SelectList? Categories { get; set; }
        public List<Recipe>? Recipes { get; set; }
    }
}