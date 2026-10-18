using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Models;

namespace Tritean_Elisa_Irina_lab2.Pages.AuthorPages;

public class DeleteModel : PageModel
{
    private readonly Tritean_Elisa_Irina_lab2Context _context;

    public DeleteModel(Tritean_Elisa_Irina_lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Author Author { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var author = await _context.Set<Author>().FirstOrDefaultAsync(m => m.ID == id);
        if (author is null)
        {
            return NotFound();
        }
        else
        {
            Author = author;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var author = await _context.Set<Author>().FindAsync(id);
        if (author != null)
        {
            Author = author;
            _context.Set<Author>().Remove(Author);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
