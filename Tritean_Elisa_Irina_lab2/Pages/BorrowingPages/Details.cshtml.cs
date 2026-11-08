using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Models;

namespace Tritean_Elisa_Irina_lab2.Pages.BorrowingPages;

public class DetailsModel : PageModel
{
    private readonly Tritean_Elisa_Irina_lab2Context _context;
    public DetailsModel(Tritean_Elisa_Irina_lab2Context context)
    {
        _context = context;
    }

    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
            .Include(b => b.Book)
                .ThenInclude(b => b.Author) // opțional, dacă vrei și autorul cărții
            .Include(b => b.Member)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (borrowing == null)
        {
            return NotFound();
        }
        else
        {
            Borrowing = borrowing;
        }
        return Page();
    }
}
