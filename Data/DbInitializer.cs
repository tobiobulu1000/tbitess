using System.Linq;
using TBitesRestaurant.Models;

namespace TBitesRestaurant.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.FoodItems.Any()) return; // ✅ Skip if data already exists

            var foodItems = new FoodItem[]
            {
                new FoodItem { Item_Name = "Shepherd’s Pie", Item_Desc = "Tasty shepherd’s pie packed with flavor.", Price = 12.99m, Available = true, Vegetarian = false },
                new FoodItem { Item_Name = "Cottage Pie", Item_Desc = "Delicious cottage pie with meat and potatoes.", Price = 10.99m, Available = true, Vegetarian = false },
                new FoodItem { Item_Name = "Haggis, Neeps & Tatties", Item_Desc = "Scotland’s national dish.", Price = 15.99m, Available = true, Vegetarian = false },
                new FoodItem { Item_Name = "Bangers and Mash", Item_Desc = "Sausages with mashed potatoes.", Price = 11.49m, Available = true, Vegetarian = false },
                new FoodItem { Item_Name = "Toad in the Hole", Item_Desc = "Sausages baked in Yorkshire pudding.", Price = 9.99m, Available = true, Vegetarian = false }
            };

            context.FoodItems.AddRange(foodItems);
            context.SaveChanges(); // ✅ Save changes to the database
        }
    }
}