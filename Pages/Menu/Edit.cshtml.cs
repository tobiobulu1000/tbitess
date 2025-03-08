using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TBitesRestaurant.Data; // ✅ Fixed namespace
using TBitesRestaurant.Models; // ✅ Fixed namespace

namespace TBitesRestaurant.Pages.Menu // ✅ Ensure correct namespace
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context; // ✅ Use `ApplicationDbContext`

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; } = default!; // ✅ Ensure non-nullable initialization

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            FoodItem = await _context.FoodItems.FirstOrDefaultAsync(m => m.Id == id);

            if (FoodItem == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(FoodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.FoodItems.Any(e => e.Id == FoodItem.Id)) return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}