using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TBitesRestaurant.Data;
using TBitesRestaurant.Models;

namespace TBitesRestaurant.Pages.Menu
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; } = new FoodItem();

        [BindProperty]
        public IFormFile FoodImage { get; set; } // ✅ Bind file input

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // ✅ Handle Image Upload (Loop through all uploaded files)
            foreach (var file in Request.Form.Files)
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    FoodItem.ImageData = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                }
            }

            _context.FoodItems.Add(FoodItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}