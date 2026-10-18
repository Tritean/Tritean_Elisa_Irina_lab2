using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Models;

namespace Tritean_Elisa_Irina_lab2.Pages.PublisherPages;

public class DetailsModel : PageModel
{
    private readonly Tritean_Elisa_Irina_lab2Context _context;
    public DetailsModel(Tritean_Elisa_Irina_lab2Context context)
    {
        _context = context;
    }

    public Publisher Publisher { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publisher = await _context.Set<Publisher>().FirstOrDefaultAsync(m => m.ID == id);
        if (publisher is null)
        {
            return NotFound();
        }
        else
        {
            Publisher = publisher;
        }

        return Page();
    }
}
