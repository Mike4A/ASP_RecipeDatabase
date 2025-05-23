using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeDatabase.Data;
using RecipeDatabase.Models;
using SQLitePCL;
using System.Data.SqlTypes;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
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

        public IActionResult Create()
        {
            WriteCategoriesIntoViewData();
            return View();
        }

        private void WriteCategoriesIntoViewData()
        {
            IQueryable<string> categoryQuery = from r in _context.Recipes​
                                               where r.Category != string.Empty
                                               orderby r.Category
                                               select r.Category;
            var categories = categoryQuery.Distinct().ToList().Select(
                c => new SelectListItem { Value = c, Text = c });
            ViewData["Categories"] = categories;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name, Slug, Category, ImagePath, Description, RecipeInstructions")] Recipe recipe,
            IFormFile ImagePath)
        {
            if (ModelState.IsValid)
            {
                if (ImagePath != null && ImagePath.Length > 0)
                {
                    var fileName = Path.GetFileName(ImagePath.FileName);
                    var filePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/images", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ImagePath.CopyTo(fileStream);
                    }
                    // Save the file path relative to the wwwroot
                    recipe.ImagePath = $"/images/{fileName}";
                }
                _context.Add(recipe);
                _context.SaveChanges();
                return RedirectToAction("Recipe", "Recipe", new { id = recipe.Id });
            }
            WriteCategoriesIntoViewData();
            return View(recipe);
        }
    }
}