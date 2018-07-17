using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Models
{
    public class BorrowersBooks
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int BorrowerId { get; set; }

        public Borrower Borrower { get; set; }
    }
}
