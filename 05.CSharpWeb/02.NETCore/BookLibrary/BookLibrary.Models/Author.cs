using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
