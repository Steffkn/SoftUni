using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Data;
using BookLibrary.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Pages.Books
{
    public class StatusModel : PageModel
    {
        public StatusModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public BookLibraryDbContext Context { get; private set; }

        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public List<BorrowViewModel> BookHistory { get; set; }

        public IActionResult OnGet(int bookId)
        {
            var book = this.Context.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                return this.RedirectToPage("/Index");
            }

            this.BookHistory = this.Context.BookBorrowsHistory
                .Where(b => b.BookId == bookId)
                .OrderByDescending(b => b.StartDate)
                .Select(BorrowViewModel.FromBookBorrowHistory)
                .ToList();

            this.BookId = book.Id;
            this.BookTitle = book.Title;
            this.AuthorId = book.Author.Id;
            this.AuthorName = book.Author.Name;

            return this.Page();
        }
    }
}