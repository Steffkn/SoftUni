using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
