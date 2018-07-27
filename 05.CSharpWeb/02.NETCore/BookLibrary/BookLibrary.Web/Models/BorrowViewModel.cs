using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateProperty(this.StartDate,
                new ValidationContext(this, null, null) { MemberName = "StartDate" },
                results);

            Validator.TryValidateProperty(this.EndDate,
                new ValidationContext(this, null, null) { MemberName = "EndDate" },
                results);

            return results;
        }
    }
}
