namespace _06.BookLibraryExtension
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class BookLibraryExtension
    {
        private const string Format = "dd.MM.yyyy";

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Book> library = new List<Book>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                library.Add(
                    new Book(
                        input[0],
                        input[1],
                        input[2],
                        DateTime.ParseExact(input[3], Format, CultureInfo.InvariantCulture),
                        input[4],
                        decimal.Parse(input[5])));
            }

            DateTime date = DateTime.ParseExact(Console.ReadLine(), Format, CultureInfo.InvariantCulture);

            library
                .Where(x => x.ReleaseDate > date)
                .OrderBy(x => x.ReleaseDate)
                .ThenBy(x => x.Title)
                .ToList()
                .ForEach(x => Console.WriteLine("{0} -> {1}", x.Title, x.ReleaseDate.ToString("dd.MM.yyyy")));
        }
    }

    public class Book
    {
        // title, author, publisher, release date(in dd.MM.yyyy format), ISBN-number and price.
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public Book(string title, string author, string publisher, DateTime releaseDate, string ISBN, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.ISBN = ISBN;
            this.Price = price;
        }
    }
}