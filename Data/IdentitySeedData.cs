using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TBitesRestaurant.Data;

namespace TBitesRestaurant.Data
{
    public static class IdentitySeedData
    {
        public static async Task Initialize(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Apply any pending migrations
            await context.Database.MigrateAsync();

            // Define roles
            string[] roles = { "Admin", "Member" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create default Admin user
            string adminEmail = "admin@tbites.com";
            string adminPassword = "Ayomide11!";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create default Member user
            string memberEmail = "member@tbites.com";
            string memberPassword = "Ayomide11@";

            if (await userManager.FindByEmailAsync(memberEmail) == null)
            {
                var memberUser = new IdentityUser
                {
                    UserName = memberEmail,
                    Email = memberEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(memberUser, memberPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(memberUser, "Member");
                }
            }
        }
    }
}