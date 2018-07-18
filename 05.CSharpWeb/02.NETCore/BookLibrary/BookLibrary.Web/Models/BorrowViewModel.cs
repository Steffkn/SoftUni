using BookLibrary.Models;
using System;

namespace BookLibrary.Web.Models
{
    public class BorrowViewModel
    {
        public int Id { get; set; }

        public string BorrowerName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public static Func<BookBorrowHistory, BorrowViewModel> FromBookBorrowHistory
        {
            get
            {
                return book => new BorrowViewModel()
                {
                    Id = book.Id,
                    BorrowerName = book.BorrowerName,
                    StartDate = book.StartDate,
                    EndDate = book.EndDate
                };
            }
        }
    }
}
