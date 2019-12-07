using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public HashSet<Cell> Cells { get; set; }
        public HashSet<Officer> Officers { get; set; }
    }
}
