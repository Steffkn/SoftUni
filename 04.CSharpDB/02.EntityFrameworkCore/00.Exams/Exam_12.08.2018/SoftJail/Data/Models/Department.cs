using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(25), Required]
        public string Name { get; set; }

        public ICollection<Cell> Cells { get; set; } = new HashSet<Cell>();

        public ICollection<Officer> Officers { get; set; } = new HashSet<Officer>();
    }
}
