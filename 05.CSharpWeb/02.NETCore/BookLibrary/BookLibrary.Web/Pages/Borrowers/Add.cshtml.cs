using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLibrary.Web.Pages.Borrowers
{
    public class AddModel : PageModel
    {
        public AddModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        [BindProperty]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string BorrowerName { get; set; }

        [BindProperty]
        [Display(Name = "Address")]
        public string BorrowerAddress { get; set; }

        public BookLibraryDbContext Context { get; private set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            this.BorrowerName = this.BorrowerName.Trim();

            var borrower = this.Context.Borrowers.FirstOrDefault(a => a.Name.ToLower() == this.BorrowerName.ToLower());

            if (borrower != null)
            {
                this.ModelState.AddModelError("error", $"Borrower with name '{BorrowerName}' already exists!");
                return this.Page();
            }

            borrower = new Borrower()
            {
                Address = this.BorrowerAddress,
                Name = this.BorrowerName
            };

            this.Context.Borrowers.Add(borrower);
            this.Context.SaveChanges();

            return this.RedirectToPage("/Index");
        }
    }
}