using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TBitesRestaurant.Data;
using TBitesRestaurant.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBitesRestaurant.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<FoodItem> FoodItem { get; set; } = new List<FoodItem>();
        public bool IsAdmin { get; set; } = false;

        // ✅ ADD THIS: BindProperty for Search
        [BindProperty]
        public string Search { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            // ✅ Fetch Food Items
            FoodItem = await _context.FoodItems.ToListAsync();

            // ✅ Check if user is Admin
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    IsAdmin = roles.Contains("Admin"); // ✅ Check if user is an Admin
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSearchAsync()
        {
            // ✅ Ensure Search is not empty
            if (!string.IsNullOrWhiteSpace(Search))
            {
                FoodItem = await _context.FoodItems
                    .Where(f => f.Item_Name.Contains(Search) || f.Item_Desc.Contains(Search))
                    .ToListAsync();
            }
            else
            {
                FoodItem = await _context.FoodItems.ToListAsync(); // Reset if empty search
            }

            return Page();
        }
    }
}