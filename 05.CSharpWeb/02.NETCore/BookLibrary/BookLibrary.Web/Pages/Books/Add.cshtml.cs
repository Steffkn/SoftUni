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

            var book = new Book()
            {
                Title = this.Title,
                Description = this.Description,
                CoverImage = this.ImageUrl,
                AuthorId = author.Id
            };

            this.Context.Books.Add(book);
            this.Context.SaveChanges();
            return book;
        }

        private Author CreateOrUpdateAuthor()
        {
            var author = this.Context.Authors.FirstOrDefault(a => a.Name == this.AuthorName);

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