using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Models
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        public string YoutubeIdURL { get; set; }

        public bool IsInStock { get; set; }
    }
}
