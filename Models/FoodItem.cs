using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBitesRestaurant.Models
{
    public class FoodItem
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Item_Name { get; set; }

        [Required, StringLength(255)]
        public string Item_Desc { get; set; }

        public bool Available { get; set; }
        public bool Vegetarian { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal? Price { get; set; }

        [StringLength(250)]
        public string ImageDescription { get; set; } // Stores the image description

        public byte[] ImageData { get; set; } // Stores the image as binary data (BLOB)
    }
}