using BookLibrary.Models;
using System;

namespace BookLibrary.Web.Models
{
    public class MovieConciseViewModel
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public bool IsInStock { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public static Func<Movie, MovieConciseViewModel> FromMovie
        {
            get
            {
                return movie => new MovieConciseViewModel()
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    AuthorId = movie.AuthorId,
                    AuthorName = movie.Author.Name,
                    IsInStock = movie.IsInStock,
                };
            }
        }
    }
}
