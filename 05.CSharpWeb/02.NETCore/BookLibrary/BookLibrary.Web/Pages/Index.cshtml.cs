using System.Collections.Generic;
using System.Linq;
using BookLibrary.Data;
using BookLibrary.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public BookLibraryDbContext Context { get; }

        public IEnumerable<BookConciseViewModel> Books { get; private set; }

        public void OnGet()
        {
            this.Books = this.Context.Books.OrderBy(b => b.Title)
                .Include(b => b.Author)
                .Select(BookConciseViewModel.FromBook)
                .ToList();
        }
    }
}
