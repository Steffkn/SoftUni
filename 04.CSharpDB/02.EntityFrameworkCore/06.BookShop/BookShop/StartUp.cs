namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static int goldEditionNumberOfCopies = 5000;

        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                // DbInitializer.ResetDatabase(db);
                string input = Console.ReadLine();
                IncreasePrices(db);
                
            }
        }

        // 14
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200);

            int count = books.Count();

            context.Books.RemoveRange(books);
            context.SaveChanges();
            return count;
        }

        // 13
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // 13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
              .Select(c => new
              {
                  RecentBooks = c.CategoryBooks.Select(b => new { b.Book.Title, b.Book.ReleaseDate }).OrderByDescending(b => b.ReleaseDate).Take(3),
                  Name = c.Name
              })
              .OrderBy(c => c.Name);

            StringBuilder result = new StringBuilder();
            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Name}");
                foreach (var book in category.RecentBooks)
                {
                    result.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return result.ToString().Trim();
        }

        // 12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
              .Select(c => new
              {
                  Profit = c.CategoryBooks.Select(b => b.Book.Price * b.Book.Copies).Sum(),
                  Name = c.Name
              })
              .OrderByDescending(c => c.Profit)
              .ThenBy(c => c.Name);

            StringBuilder result = new StringBuilder();
            foreach (var category in categories)
            {
                result.AppendLine($"{category.Name} ${category.Profit}");
            }

            return result.ToString().Trim();
        }

        // 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
               .Select(a => new
               {
                   TotalCopies = a.Books.Sum(b => b.Copies),
                   FirstName = a.FirstName,
                   LastName = a.LastName
               })
               .OrderByDescending(title => title.TotalCopies);

            StringBuilder result = new StringBuilder();
            foreach (var author in authors)
            {
                result.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalCopies}");
            }

            return result.ToString().Trim();
        }

        // 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books
             .Where(b => b.Title.Length > lengthCheck)
             .Count();

            return count;
        }

        // problem 09
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string searchTerm = input.Trim().ToLower();
            var titles = context.Books
               .Where(b => b.Author.LastName.ToLower().StartsWith(searchTerm))
               .Select(b => new
               {
                   Title = b.Title,
                   BookId = b.BookId,
                   AuthorFirstName = b.Author.FirstName,
                   AuthorLastName = b.Author.LastName
               })
               .OrderBy(title => title.BookId);

            StringBuilder result = new StringBuilder();
            foreach (var book in titles)
            {
                result.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return result.ToString().Trim();
        }

        // Problem 08
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string searchTerm = input.Trim().ToLower();
            var titles = context.Books
               .Where(b => b.Title.ToLower().Contains(searchTerm))
               .Select(b => b.Title)
               .OrderBy(title => title);

            StringBuilder result = new StringBuilder();
            foreach (var title in titles)
            {
                result.AppendLine($"{title}");
            }

            return result.ToString().Trim();
        }

        // Problem 07
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                  .Where(a => a.FirstName.EndsWith(input))
                  .Select(a => $"{a.FirstName} {a.LastName}")
                  .OrderBy(name => name);

            StringBuilder result = new StringBuilder();
            foreach (var name in authorNames)
            {
                result.AppendLine($"{name}");
            }

            return result.ToString().Trim();
        }

        // Problem 06
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime wantedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var bookTitles = context.Books
                  .Where(b => b.ReleaseDate.Value < wantedDate)
                  .OrderByDescending(b => b.ReleaseDate)
                  .Select(b => new
                  {
                      b.Title,
                      b.EditionType,
                      b.Price
                  });

            StringBuilder result = new StringBuilder();
            foreach (var book in bookTitles)
            {
                result.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price:f2}");
            }

            return result.ToString().Trim();
        }


        // Problem 05
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder result = new StringBuilder();

            var bookTitles = context.Books
                    .Select(p => new
                    {
                        Book = p,
                        Categories = p.BookCategories
                                        .Select(c => c.Category)
                                        .Where(c => categories.Contains(c.Name.ToLower()))
                    })
                  .Where(b => b.Categories.Count() > 0)
                  .Select(b => b.Book.Title)
                  .OrderBy(t => t)
                  .ToList();

            foreach (var title in bookTitles)
            {
                result.AppendLine($"{title}");
            }

            return result.ToString().Trim();
        }

        // Problem 04
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder result = new StringBuilder();

            var bookTitles = context.Books
                  .Where(b => b.ReleaseDate.Value.Year != year)
                  .OrderBy(b => b.BookId)
                  .Select(b => b.Title);

            foreach (var title in bookTitles)
            {
                result.AppendLine($"{title}");
            }

            return result.ToString().Trim();
        }

        // Problem 03
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var bookTitles = context.Books
                  .Where(b => b.Price > 40)
                  .OrderByDescending(b => b.Price);

            foreach (var book in bookTitles)
            {
                result.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return result.ToString().Trim();
        }

        // Problem 02
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var bookTitles = context.Books
                  .Where(b => b.EditionType == EditionType.Gold && b.Copies <= goldEditionNumberOfCopies)
                  .OrderBy(b => b.BookId)
                  .Select(b => b.Title);

            foreach (var title in bookTitles)
            {
                result.AppendLine(title);
            }

            return result.ToString();
        }

        // Problem 01
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder result = new StringBuilder();

            AgeRestriction ageRestriction;
            if (Enum.TryParse(command, true, out ageRestriction))
            {
                var bookTitles = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .Select(b => b.Title)
                    .OrderBy(t => t);

                foreach (string title in bookTitles)
                {
                    result.AppendLine(title);
                }
            }

            return result.ToString();
        }
    }
}
