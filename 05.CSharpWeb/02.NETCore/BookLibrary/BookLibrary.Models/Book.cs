using System.Collections.Generic;

namespace BookLibrary.Models
{
    public class Book
    {
        public Book()
        {
            this.Borrowers = new HashSet<BorrowersBooks>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CoverImage { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<BorrowersBooks> Borrowers { get; set; }
    }
}
