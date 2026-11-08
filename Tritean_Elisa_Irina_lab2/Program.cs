using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuram conexiunea la baza de date principala a proiectului
var connectionString = builder.Configuration.GetConnectionString("Tritean_Elisa_Irina_lab2Context") ?? throw new InvalidOperationException("Connection string 'Tritean_Elisa_Irina_lab2Context' not found.");

builder.Services.AddDbContext<Tritean_Elisa_Irina_lab2Context>(options =>
    options.UseSqlServer(connectionString));

// Inregistrăm Identity folosind contextul principal al aplicatiei
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Tritean_Elisa_Irina_lab2Context>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();