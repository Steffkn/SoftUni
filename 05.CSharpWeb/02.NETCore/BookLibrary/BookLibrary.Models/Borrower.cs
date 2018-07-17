using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Models
{
    public class Borrower
    {
        public Borrower()
        {
            this.BorrowedBooks = new HashSet<BorrowersBooks>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<BorrowersBooks> BorrowedBooks { get; set; }
    }
}
