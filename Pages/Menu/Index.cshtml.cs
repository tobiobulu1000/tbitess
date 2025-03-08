using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TBitesRestaurant.Data;
using TBitesRestaurant.Models;

namespace Tbites_Restaurant.Pages.Menu // Ensure this matches your project namespace
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FoodItem> FoodItem { get; set; } = new List<FoodItem>();

        public async Task OnGetAsync()
        {
            if (_context.FoodItems != null)
            {
                FoodItem = await _context.FoodItems.ToListAsync();
            }
        }
    }
}