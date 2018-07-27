using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Pages
{
    public class SearchModel : PageModel
    {
        public SearchModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public BookLibraryDbContext Context { get; }

        public IEnumerable<Book> Books { get; set; }

        public IEnumerable<Movie> Movies { get; set; }

        public string SearchTerm { get; set; }

        public void OnGet(string searchTerm)
        {
            this.SearchTerm = searchTerm.Trim();
            this.Books = this.Context.Books
               .Include(b => b.Author)
               .Where(b => b.Title.Contains(this.SearchTerm, StringComparison.CurrentCultureIgnoreCase)
                        || b.Author.Name.Contains(this.SearchTerm, StringComparison.CurrentCultureIgnoreCase))
               .ToList();

            this.Movies = this.Context.Movies
               .Include(b => b.Author)
               .Where(b => b.Title.Contains(this.SearchTerm, StringComparison.CurrentCultureIgnoreCase)
                        || b.Author.Name.Contains(this.SearchTerm, StringComparison.CurrentCultureIgnoreCase))
               .ToList();

            if (!Books.Any() && !Movies.Any())
            {
                this.ModelState.AddModelError("error", $"No results found for: '{this.SearchTerm}'");
            }
        }
    }
}