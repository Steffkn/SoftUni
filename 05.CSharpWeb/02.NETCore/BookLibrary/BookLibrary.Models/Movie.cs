using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Borrowers = new HashSet<BorrowersMovies>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public string YoutubeTrailerId { get; set; }

        public bool IsInStock { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<BorrowersMovies> Borrowers { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
