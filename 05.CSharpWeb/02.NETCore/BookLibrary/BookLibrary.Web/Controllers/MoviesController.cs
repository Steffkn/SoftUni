using BookLibrary.Data;
using BookLibrary.Models;
using BookLibrary.Web.Models;
using BookLibrary.Web.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookLibrary.Web.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public BookLibraryDbContext Context { get; private set; }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult Add(MovieBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            Author author = CreateOrUpdateAuthor(model.ProducerName);

            if (model.Title.ToLower().StartsWith("the "))
            {
                model.Title = string.Format("{0}, {1}", model.Title.Substring(4), model.Title.Substring(0, 3));
            }

            var movies = new Movie()
            {
                Title = model.Title.Trim(),
                Description = model.Description?.Trim(),
                YoutubeTrailerId = model.YoutubeTrailerId.Trim(),
                AuthorId = author.Id,
                IsInStock = true
            };

            this.Context.Movies.Add(movies);
            this.Context.SaveChanges();
            return this.RedirectToPage("/Index");
        }

        private Author CreateOrUpdateAuthor(string authorName)
        {
            var author = this.Context.Authors.FirstOrDefault(a => a.Name.ToLower() == authorName.ToLower());

            if (author == null)
            {
                author = new Author()
                {
                    Name = authorName
                };

                this.Context.Authors.Add(author);
            }

            return author;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie = this.Context.Movies
                  .Include(b => b.Author)
                  .FirstOrDefault(b => b.Id == id);

            if (movie == null)
            {
                return this.RedirectToPage("/Index");
            }

            MovieViewModel movieVM = new MovieViewModel()
            {
                MovieId = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                AuthorName = movie.Author.Name,
                AuthorId = movie.Author.Id,
                YoutubeIdURL = movie.YoutubeTrailerId,
                IsInStock = movie.IsInStock,
            };

            return this.View(movieVM);
        }

        [HttpGet]
        public IActionResult Return(int id)
        {
            var movie = this.Context.Movies.Find(id);

            if (movie == null)
            {
                return this.RedirectToPage("/Index");
            }

            var borrower = this.Context.Borrowers
                .Include(b => b.BorrowedMovies)
                .FirstOrDefault(b => b.BorrowedMovies.Any(d => d.MovieId == id));

            if (borrower != null)
            {
                borrower.BorrowedMovies
                    .Remove(borrower.BorrowedMovies.First(a => a.MovieId == id));
            }

            movie.IsInStock = true;

            this.Context.SaveChanges();

            return this.RedirectToPage("/Index");
        }

        [HttpGet]
        public IActionResult Borrow(int id)
        {
            var movie = this.Context.Movies.Find(id);

            if (movie == null)
            {
                return this.RedirectToPage("/Index");
            }

            MovieBorrowViewModel borrowModel = new MovieBorrowViewModel()
            {
                MovieId = movie.Id,
                MovieTitle = movie.Title
            };

            borrowModel.Borrowers = GetBorrowers().ToList();

            return this.View(borrowModel);
        }

        [HttpPost]
        public IActionResult Borrow(MovieBorrowViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Borrowers = GetBorrowers().ToList();
                return this.View(model);
            }

            var movie = this.Context.Movies.Find(model.MovieId);
            if (movie == null)
            {
                return this.RedirectToPage("/Index");
            }

            if (model.EndDate.HasValue && model.StartDate > model.EndDate)
            {
                this.ModelState.AddModelError("error", "Start date must be before end date!");
                model.Borrowers = GetBorrowers().ToList();
                return this.View(model);
            }

            var borrower = this.Context.Borrowers.Include(b => b.BorrowedBooks).FirstOrDefault(b => b.Id == model.BorrowerId);

            if (borrower == null)
            {
                return this.RedirectToPage("/Borrowers/Add");
            }

            borrower.BorrowedMovies.Add(new BorrowersMovies()
            {
                MovieId = movie.Id,
                BorrowerId = model.BorrowerId
            });

            movie.IsInStock = false;

            // add history

            this.Context.SaveChanges();

            return this.RedirectToPage("/Index");
        }

        private IQueryable<SelectListItem> GetBorrowers()
        {
            var borrowersQuery = this.Context.Borrowers
                .Select(b => new SelectListItem() { Text = b.Name, Value = b.Id.ToString() });
            return borrowersQuery;
        }
    }
}
