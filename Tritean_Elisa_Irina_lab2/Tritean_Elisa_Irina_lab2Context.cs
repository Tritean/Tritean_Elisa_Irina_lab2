using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Data;

public class Tritean_Elisa_Irina_lab2Context(DbContextOptions<Tritean_Elisa_Irina_lab2Context> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Author> Author { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Category> Category { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.BookCategory> BookCategory { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Member> Member { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Borrowing> Borrowing { get; set; } = default!;
}