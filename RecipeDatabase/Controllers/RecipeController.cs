using Microsoft.AspNetCore.Mvc;
using RecipeDatabase.Models;
using System.Data.SqlTypes;
namespace RecipeDatabase.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Recipe()
        {
            Recipe recipe = new Recipe();
            recipe.Name = "Cheese Toastie";
            recipe.Category = "Snacks";
            recipe.Description = "A luxurious sandwich fit for any meal";
            recipe.ImagePath = @"\images\cheesetoastie.webp";
            recipe.RecipeInstructions = "1. Preheat a skillet or griddle over medium heat.<br>2. Butter one side of each bread slice.<br>3. Place one slice of bread, butter side down, on the skillet.<br>4. Add the cheese slices on top of the bread in the skillet, covering the entire surface.<br>5. Place the second slice of bread on top of the cheese, butter side up.<br>6. Cook for 2-3 minutes, or until the bottom slice is golden brown and the cheese starts to melt.<br>7. Carefully flip the sandwich using a spatula and cook the other side for an additional 2-3 minutes, or until golden brown and the cheese is fully melted.<br>8. Remove the cheese toastie from the skillet and let it cool for a minute.<br>9. Cut the sandwich diagonally into two triangles.<br>10. Serve hot and enjoy your delicious cheese toastie!";
            return View(recipe);
        }
    }
}