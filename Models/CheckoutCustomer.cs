using System.ComponentModel.DataAnnotations;

namespace TBitesRestaurant.Models
{
    public class CheckoutCustomer
    {
        [Key]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public int BasketID { get; set; } // Foreign key to Basket
    }
}