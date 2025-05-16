using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeDatabase.Data;
using RecipeDatabase.Models;
using SQLitePCL;
using System.Data.SqlTypes;
namespace RecipeDatabase.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Recipes(string searchString)
        {
            var recipes = from r in _context.Recipes select r;
            if (!string.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.Name.ToLower().Contains(searchString.ToLower()));
            }
            return View(recipes);
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