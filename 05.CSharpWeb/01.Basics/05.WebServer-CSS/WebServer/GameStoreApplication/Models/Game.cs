namespace HTTPServer.GameStoreApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string Image { get; set; }

        public string SizeGB { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<UserGame> UserGames { get; set; }
    }
}
