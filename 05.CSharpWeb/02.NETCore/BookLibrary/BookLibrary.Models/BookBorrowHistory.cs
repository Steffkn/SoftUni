using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class BookBorrowHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BorrowerName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
    }
}
