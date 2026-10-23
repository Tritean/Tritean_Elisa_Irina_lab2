using Microsoft.EntityFrameworkCore;

public class Tritean_Elisa_Irina_lab2Context(DbContextOptions<Tritean_Elisa_Irina_lab2Context> options) : DbContext(options)
{
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Author> Author { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.Category> Category { get; set; } = default!;
    public DbSet<Tritean_Elisa_Irina_lab2.Models.BookCategory> BookCategory { get; set; } = default!;
}
