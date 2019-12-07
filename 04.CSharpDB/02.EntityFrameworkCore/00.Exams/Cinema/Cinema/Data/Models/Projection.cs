using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data.Models
{
    public class Projection
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public HashSet<Ticket> Tickets { get; set; }
    }
}
