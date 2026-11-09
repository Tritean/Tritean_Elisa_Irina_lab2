using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Tritean_Elisa_Irina_lab2Context") ?? throw new InvalidOperationException("Connection string 'Tritean_Elisa_Irina_lab2Context' not found.");

builder.Services.AddDbContext<Tritean_Elisa_Irina_lab2Context>(options =>
    options.UseSqlServer(connectionString));

// Identity cu ApplicationUser + roluri
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Tritean_Elisa_Irina_lab2Context>();

// Politica de autorizare 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/MemberPages", "AdminPolicy");
    // Publishers si Categories doar pentru Admim
    options.Conventions.AuthorizeFolder("/PublisherPages", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/CategoryPages", "AdminPolicy");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();