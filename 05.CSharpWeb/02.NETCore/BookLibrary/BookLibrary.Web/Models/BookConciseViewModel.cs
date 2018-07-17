using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Models
{
    public class BookConciseViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public static Func<Book, BookConciseViewModel> FromBook
        {
            get
            {
                return book => new BookConciseViewModel()
                {
                    BookId = book.Id,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    AuthorName = book.Author.Name,
                };
            }
        }
    }
}
