using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TBitesRestaurant.Data; // ✅ Correct namespace
using TBitesRestaurant.Models; // ✅ Correct namespace

namespace TBitesRestaurant.Pages.Menu // ✅ Ensure this matches your project namespace
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context; // ✅ Use `ApplicationDbContext` instead of `IdentityDbContext`

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public FoodItem FoodItem { get; set; } // ✅ No need to specify full namespace

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodItem = await _context.FoodItems.FirstOrDefaultAsync(m => m.Id == id);

            if (FoodItem == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}