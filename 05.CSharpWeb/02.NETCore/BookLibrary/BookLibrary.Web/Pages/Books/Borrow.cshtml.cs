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
        public DateTime StartDate { get; set; }

        [BindProperty]
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [BindProperty]
        [Display(Name = "Borrower")]
        [Required(ErrorMessage = "Select a borrower or add new one!")]
        public int BorrowerId { get; set; }

        public void OnGet(int bookId)
        {
            StartDate = DateTime.Today;
            GetBorrowers();
        }

        public void OnGetReturn(int bookId)
        {

        }

        public IActionResult OnPost(int bookId)
        {
            if (!ModelState.IsValid)
            {
                this.GetBorrowers();
                return this.Page();
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
                BookId = bookId,
                BorrowerId = this.BorrowerId
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