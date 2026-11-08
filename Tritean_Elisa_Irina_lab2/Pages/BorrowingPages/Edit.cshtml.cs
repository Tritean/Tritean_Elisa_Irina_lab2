using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tritean_Elisa_Irina_lab2.Models;

namespace Tritean_Elisa_Irina_lab2.Pages.BorrowingPages;

public class EditModel : PageModel
{
    private readonly Tritean_Elisa_Irina_lab2Context _context;

    public EditModel(Tritean_Elisa_Irina_lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
        if (borrowing == null)
        {
            return NotFound();
        }
        Borrowing = borrowing;

        // Populare pentru DropDownList - Carte (afișează Titlul)
        ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");

        // Populare pentru DropDownList - Membru (afișează Numele și Prenumele)
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName"); // sau poți concatena Nume + Prenume dacă ai o proprietate sau un string interpolat

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Borrowing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BorrowingExists(Borrowing.ID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool BorrowingExists(int id)
    {
        return _context.Borrowing.Any(e => e.ID == id);
    }
}
