using Microsoft.EntityFrameworkCore;
using RecipeDatabase.Models;
namespace RecipeDatabase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
