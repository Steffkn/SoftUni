using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public BookLibraryDbContext Context { get; }

        public IEnumerable<Book> Books { get; set; }

        public string AuthorName { get; set; }

        public IActionResult OnGet(int id)
        {
            this.Books = this.Context.Books
                .Include(b => b.Author)
                .Where(b => b.AuthorId == id)
                .ToList();

            if (Books.Any())
            {
                this.AuthorName = Books.First().Author.Name;
                return this.Page();
            }

            return RedirectToPage("/Index");
        }
    }
}