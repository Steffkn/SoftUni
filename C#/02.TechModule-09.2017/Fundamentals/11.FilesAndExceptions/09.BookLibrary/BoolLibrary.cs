namespace _09.BoolLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class BoolLibrary
    {
        public const string inputFilePath = "input.txt";
        public const string outputFilePath = "output.txt";

        static void Main()
        {
            using (StreamWriter writer = File.CreateText(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(new FileStream(inputFilePath, FileMode.Open)))
                {
                    while (!reader.EndOfStream)
                    {
                        int n = int.Parse(reader.ReadLine());

                        List<Book> library = new List<Book>();

                        for (int i = 0; i < n; i++)
                        {
                            string[] input = reader.ReadLine().Split();

                            library.Add(
                                new Book(
                                    input[0],
                                    input[1],
                                    input[2],
                                    DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                                    input[4],
                                    decimal.Parse(input[5])));
                        }

                        var dict = new Dictionary<string, decimal>();

                        foreach (var book in library)
                        {
                            if (!dict.ContainsKey(book.Author))
                            {
                                dict.Add(book.Author, book.Price);
                            }
                            else
                            {
                                dict[book.Author] = (dict[book.Author] + book.Price);
                            }
                        }

                        dict
                            .OrderByDescending(x => x.Value)
                            .ThenBy(x => x.Key)
                            .ToList()
                            .ForEach(x => writer.WriteLine($"{x.Key} -> {x.Value:F2}"));
                    }
                }
            }
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