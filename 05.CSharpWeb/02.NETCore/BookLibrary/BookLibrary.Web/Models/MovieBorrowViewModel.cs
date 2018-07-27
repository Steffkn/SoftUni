using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Models
{
    public class MovieBorrowViewModel
    {
        public List<SelectListItem> Borrowers { get; set; }

        [BindProperty]
        [Display(Name = "Start date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date!")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        public string MovieTitle { get; set; }

        public int MovieId { get; set; }

        [BindProperty]
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [BindProperty]
        [Display(Name = "Borrower")]
        [Required(ErrorMessage = "Select a borrower or add new one!")]
        public int BorrowerId { get; set; }
    }
}
