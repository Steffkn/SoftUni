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

        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public string ImageUrl { get; set; }

        public BookLibraryDbContext Context { get; }

        public IActionResult OnGet(int id)
        {
            var book = this.Context.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            this.Title = book.Title;
            this.Description = book.Description;
            this.AuthorName = book.Author.Name;
            this.ImageUrl = book.CoverImage;

            return this.Page();
        }
    }
}