using Microsoft.EntityFrameworkCore;
using RecipeDatabase.Models;
namespace RecipeDatabase.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any recipes. If there are any, the DB has been seeded
                if (context.Recipes.Any())
                {
                    return;
                    // DB has been seeded
                }
                context.Recipes.AddRange(
                    new Recipe
                    {
                        Name = "Burgers",
                        Category = "Main Courses",
                        ImagePath = @"\images\burgers.jpg",
                        Description = "Classic beef burgers topped with fresh lettuce, ripe tomatoes, and gooey cheese. Perfect for a casual dinner or a backyard barbecue.",
                        RecipeInstructions = "1. Grill beef patties until cooked to desired doneness.<br>2. Toast buns on the grill for a minute.<br>3. Add lettuce, tomato, cheese, and patties to buns.<br>4. Serve with ketchup, mustard, or your favorite burger sauce.<br>"
                    },
                    new Recipe
                    {
                        Name = "Pizza",
                        Category = "Main Courses",
                        ImagePath = @"\images\pizza.jpg",
                        Description = "Homemade pizza layered with savory tomato sauce, mozzarella cheese, and a selection of toppings to fit any taste. Ideal for family movie nights.",
                        RecipeInstructions = "1. Spread sauce on rolled out dough.<br>2. Sprinkle cheese generously.<br>3. Add toppings of your choice.<br>4. Bake in preheated oven at 475°F for 12-15 minutes.<br>"
                    },
                    new Recipe
                    {
                        Name = "Spaghetti Bolognese",
                        Category = "Main Courses",
                        ImagePath = @"\images\spaghetti_bolognese.jpg",
                        Description = "A hearty Italian dish featuring spaghetti topped with a meaty tomato sauce. A comfort food favorite that's both satisfying and delicious.",
                        RecipeInstructions = "1. Cook spaghetti according to package instructions.<br>2. Brown meat in a pan, add tomato sauce, and simmer.<br>3. Serve hot sauce over drained spaghetti.<br>"
                    }); 
                context.SaveChanges();
            }
        }
    }
}