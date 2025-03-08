using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TBitesRestaurant.Models
{
    public class BasketItem
    {
        [Required]
        public int StockID { get; set; }

        [Required]
        public int BasketID { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Composite Primary Key
        public static void ConfigureModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketItem>()
                .HasKey(bi => new { bi.StockID, bi.BasketID });
        }
    }
}