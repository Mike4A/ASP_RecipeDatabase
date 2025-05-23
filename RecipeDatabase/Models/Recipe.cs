using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace RecipeDatabase.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Category { get; set; }
        [Required]
        public string? ImagePath { get; set; }
        [Required]
        public string? Description { get; set; }
        [DisplayName("Recipe Instructions")]
        [Required] 
        public string? RecipeInstructions { get; set; }
    }
}

