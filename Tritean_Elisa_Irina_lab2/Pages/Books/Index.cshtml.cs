using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Models;

namespace Tritean_Elisa_Irina_lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Tritean_Elisa_Irina_lab2Context _context;

    public IndexModel(Tritean_Elisa_Irina_lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await _context.Book
    .Include(b => b.Publisher)
    .Include(b => b.Author)
    .ToListAsync();
    }
}
