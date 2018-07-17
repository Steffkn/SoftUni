using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookLibrary.Web.Pages.Books
{
    public class AddModel : PageModel
    {
        public AddModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [BindProperty]
        public string AuthorName { get; set; }

        [BindProperty]
        [Display(Name = "Image URL")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public BookLibraryDbContext Context { get; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            Book book = AddBook();
            return this.RedirectToPage("/Books/Details", new { id = book.Id });
        }

        private Book AddBook()
        {
            Author author = CreateOrUpdateAuthor();

            if (this.Title.ToLower().StartsWith("the "))
            {
                this.Title = string.Format("{0}, {1}", this.Title.Substring(4), this.Title.Substring(0, 3));
            }

            var book = new Book()
            {
                Title = this.Title.Trim(),
                Description = this.Description.Trim(),
                CoverImage = this.ImageUrl.Trim(),
                AuthorId = author.Id
            };

            this.Context.Books.Add(book);
            this.Context.SaveChanges();
            return book;
        }

        private Author CreateOrUpdateAuthor()
        {
            this.AuthorName = this.AuthorName.Trim();
            var author = this.Context.Authors.FirstOrDefault(a => a.Name.ToLower() == this.AuthorName.ToLower());

            if (author == null)
            {
                author = new Author()
                {
                    Name = this.AuthorName
                };

                this.Context.Authors.Add(author);
            }

            return author;
        }
    }
}