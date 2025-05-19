using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeDatabase.Data;
using RecipeDatabase.Models;
using SQLitePCL;
using System.Data.SqlTypes;
using System.Globalization;
namespace RecipeDatabase.Controllers
{

    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Recipes(string searchString, string recipeCategory)
        {
            // Use LINQ to get a list of categories for filtering
            IQueryable<string> categoryQuery = from r in _context.Recipes where r.Category != string.Empty orderby r.Category select r.Category;
            IQueryable<Recipe> recipes = from r in _context.Recipes select r;
            if (!string.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.Name!.ToLower().Contains(searchString.ToLower()));
            }
            if (!string.IsNullOrEmpty(recipeCategory))
            {
                recipes = recipes.Where(x => x.Category == recipeCategory);
            }
            IEnumerable<SelectListItem> categories = categoryQuery.Distinct().ToList().Select(c => new SelectListItem
            {
                Value = c,
                Text = c,
                Selected = c == recipeCategory
            });
            var recipeSearchViewModel = new RecipeSearchViewModel
            {
                Categories = new SelectList(categories, "Value", "Text", recipeCategory),
                Recipes = recipes.ToList()
            };
            return View(recipeSearchViewModel);
        }

        public IActionResult Recipe(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }
    }
}