using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Models;

namespace Tritean_Elisa_Irina_lab2.Pages.AuthorPages;

public class CreateModel : PageModel
{
    private readonly Tritean_Elisa_Irina_lab2Context _context;

    public CreateModel(Tritean_Elisa_Irina_lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Author Author { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Add(Author);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
