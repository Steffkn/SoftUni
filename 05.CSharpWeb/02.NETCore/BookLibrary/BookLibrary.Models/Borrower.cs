using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Borrower
    {
        public Borrower()
        {
            this.BorrowedBooks = new HashSet<BorrowersBooks>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public ICollection<BorrowersBooks> BorrowedBooks { get; set; }
    }
}
