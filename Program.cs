using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TBitesRestaurant.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Register Razor Pages
builder.Services.AddRazorPages();

// ✅ Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("IdentityDbContext")));

// ✅ Add Identity with Roles
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultUI()
.AddDefaultTokenProviders();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build(); // ✅ Build after all services are registered

// ✅ Apply migrations and seed roles & users
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await IdentitySeedData.Initialize(context, userManager, roleManager); // ✅ Seed roles & users
}

// ✅ Middleware Setup
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();