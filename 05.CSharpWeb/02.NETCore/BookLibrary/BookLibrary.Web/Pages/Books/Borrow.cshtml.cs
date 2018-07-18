using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Pages.Books
{
    public class BorrowModel : PageModel
    {
        public BorrowModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public BookLibraryDbContext Context { get; private set; }

        public List<SelectListItem> Borrowers { get; set; }

        [BindProperty]
        [Display(Name = "Start date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date!")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        public string BookTitle { get; set; }

        public int BookId { get; set; }

        [BindProperty]
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [BindProperty]
        [Display(Name = "Borrower")]
        [Required(ErrorMessage = "Select a borrower or add new one!")]
        public int BorrowerId { get; set; }

        public IActionResult OnGet(int bookId)
        {
            var book = this.Context.Books.Find(bookId);

            if (book == null)
            {
                return this.RedirectToPage("/Index");
            }

            this.BookId = bookId;
            this.BookTitle = book.Title;

            GetBorrowers();

            return this.Page();
        }

        public IActionResult OnGetReturn(int bookId)
        {
            var book = this.Context.Books.Find(bookId);
            if (book == null)
            {
                return this.RedirectToPage("/Index");
            }

            var borrower = this.Context.Borrowers.Include(b => b.BorrowedBooks).FirstOrDefault(b => b.BorrowedBooks.Any(d => d.BookId == bookId));

            if (borrower != null)
            {
                borrower.BorrowedBooks.Remove(borrower.BorrowedBooks.First(a => a.BookId == bookId));
            }

            book.IsInStock = true;

            var bookHistory = this.Context.BookBorrowsHistory.LastOrDefault(h => h.BookId == bookId);

            if (bookHistory != null)
            {
                bookHistory.EndDate = DateTime.Today;
            }

            this.Context.SaveChanges();

            return this.RedirectToPage("/Index");
        }

        public IActionResult OnPost(int bookId)
        {
            if (!ModelState.IsValid)
            {
                this.GetBorrowers();
                return this.Page();
            }

            var book = this.Context.Books.Find(bookId);
            if (book == null)
            {
                return this.RedirectToPage("/Index");
            }

            if (EndDate != null && StartDate > EndDate)
            {
                this.ModelState.AddModelError("error", "Start date must be before end date!");
                this.GetBorrowers();
                return this.Page();
            }

            var borrower = this.Context.Borrowers.Include(b => b.BorrowedBooks).FirstOrDefault(b => b.Id == BorrowerId);

            if (borrower == null)
            {
                return this.RedirectToPage("/Borrowers/Add");
            }

            borrower.BorrowedBooks.Add(new BorrowersBooks()
            {
                BookId = book.Id,
                BorrowerId = this.BorrowerId
            });

            book.IsInStock = false;
            this.Context.BookBorrowsHistory.Add(new BookBorrowHistory()
            {
                BookId = book.Id,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                BorrowerName = borrower.Name,
            });

            this.Context.SaveChanges();

            return this.RedirectToPage("/Index");
        }

        private void GetBorrowers()
        {
            var borrowersQuery = this.Context.Borrowers.Select(b => new SelectListItem() { Text = b.Name, Value = b.Id.ToString() });
            this.Borrowers = borrowersQuery.ToList();
        }
    }
}