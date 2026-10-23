using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tritean_Elisa_Irina_lab2.Models;

namespace Tritean_Elisa_Irina_lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Tritean_Elisa_Irina_lab2Context _context;

        public CreateModel(Tritean_Elisa_Irina_lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var book = new Book();
            book.BookCategories = new List<BookCategory>();

            PopulateAssignedCategoryData(_context, book);

            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            // Adăugăm categoriile selectate din checkbox-uri
            if (selectedCategories != null)
            {
                Book.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    Book.BookCategories.Add(catToAdd);
                }
            }

            // Verificăm dacă modelul este valid
            if (!ModelState.IsValid)
            {
                PopulateAssignedCategoryData(_context, Book);

                var authorList = _context.Author.Select(x => new
                {
                    x.ID,
                    FullName = x.LastName + " " + x.FirstName
                });
                ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
                ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}