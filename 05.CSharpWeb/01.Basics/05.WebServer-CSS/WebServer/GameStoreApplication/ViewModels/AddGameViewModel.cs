namespace HTTPServer.GameStoreApplication.ViewModels
{
    using System;

    public class AddGameViewModel
    {
        public string Title { get; set; }

        public string Trailer { get; set; }

        public string Image { get; set; }

        public string SizeGB { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
