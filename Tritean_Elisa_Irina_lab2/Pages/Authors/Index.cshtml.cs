using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Models;

namespace Tritean_Elisa_Irina_lab2.Pages.AuthorPages;

public class IndexModel : PageModel
{
    private readonly Tritean_Elisa_Irina_lab2Context _context;

    public IndexModel(Tritean_Elisa_Irina_lab2Context context)
    {
        _context = context;
    }

    public IList<Author> Author { get; set; } = default!;

    public async Task OnGetAsync()
    {
    Author = await _context.Author
        .Include(a => a.Books)
        .ToListAsync();
    }
}
