using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tritean_Elisa_Irina_lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        // Titlu obligatoriu, intre 3 si 150 de caractere
        [Display(Name = "Book Title")]
        [Required(ErrorMessage = "Titlul cartii este obligatoriu")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Titlul trebuie sa aiba intre 3 si 150 de caractere")]
        public string Title { get; set; }

        public int? AuthorID { get; set; }
        public Author? Author { get; set; } // Proprietate de navigare

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<Borrowing>? Borrowings { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; } // Proprietate de navigare pentru relația many-to-many
    }
}