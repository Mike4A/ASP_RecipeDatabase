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

        public IActionResult Recipes()
        {
            var recipes = from r in _context.Recipes select r;
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