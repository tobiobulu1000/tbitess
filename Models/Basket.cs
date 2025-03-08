using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TBitesRestaurant.Models
{
    public class Basket
    {
        [Key]
        public int BasketID { get; set; }

        // Navigation property
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}