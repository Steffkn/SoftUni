﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LogoUrl { get; set; }
        [Required]
        public string Initials { get; set; }
        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
        public ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();
        public ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();
    }
}