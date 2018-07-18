using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Book
    {
        public Book()
        {
            this.Borrowers = new HashSet<BorrowersBooks>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public string CoverImage { get; set; }

        public bool IsInStock { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<BorrowersBooks> Borrowers { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
