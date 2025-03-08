using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TBitesRestaurant.Models;

namespace TBitesRestaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; } = default!;
        //public DbSet<CheckoutCustomer> CheckoutCustomers { get; set; } = default!;
       // public DbSet<Basket> Baskets { get; set; } = default!;
        //public DbSet<BasketItem> BasketItems { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Assign table names
            modelBuilder.Entity<FoodItem>().ToTable("FoodItems");
            //modelBuilder.Entity<CheckoutCustomer>().ToTable("CheckoutCustomers");
            //modelBuilder.Entity<Basket>().ToTable("Baskets");
            //modelBuilder.Entity<BasketItem>().ToTable("BasketItems");

            // Composite Key for BasketItem
            modelBuilder.Entity<BasketItem>()
                .HasKey(bi => new { bi.StockID, bi.BasketID });
        }
    }
}