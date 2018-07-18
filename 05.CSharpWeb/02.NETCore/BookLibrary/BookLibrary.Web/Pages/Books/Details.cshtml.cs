using System.Linq;
using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Pages.Books
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public int BookId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        public string ImageUrl { get; set; }

        public bool IsInStock { get; set; }

        public BookLibraryDbContext Context { get; }

        public IActionResult OnGet(int id)
        {
            var book = this.Context.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.RedirectToPage("/Index");
            }

            this.BookId = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.AuthorName = book.Author.Name;
            this.AuthorId = book.Author.Id;
            this.ImageUrl = book.CoverImage;
            this.IsInStock = book.IsInStock;

            return this.Page();
        }
    }
}