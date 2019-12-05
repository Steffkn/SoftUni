using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data.Models
{
    public class Ticket
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(typeof(decimal), "0.1", "79228162514264337593543950335")]
        public decimal Price { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }
    }
}
