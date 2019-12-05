namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Any()))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("f2"),
                    Customers = x.Projections.SelectMany(p => p.Tickets)
                                                .Select(c => new
                                                {
                                                    c.Customer.FirstName,
                                                    c.Customer.LastName,
                                                    Balance = c.Customer.Balance.ToString("f2")
                                                })
                                                .OrderByDescending(cc => cc.Balance)
                                                .ThenBy(cc => cc.FirstName)
                                                .ThenBy(cc => cc.LastName)
                })
                .Take(10)
                .ToList();


            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
            };

            var json = JsonConvert.SerializeObject(movies, jsonSettings);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(c => c.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(t => t.Price))
                .Select(c => new CustomerDTO
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(t => t.Price).ToString("f2"),
                    SpentTime = new TimeSpan(c.Tickets.Sum(t => t.Projection.Movie.Duration.Hours),
                                                c.Tickets.Sum(t => t.Projection.Movie.Duration.Minutes),
                                                c.Tickets.Sum(t => t.Projection.Movie.Duration.Seconds))
                                    .ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToList();

            var serializer = new XmlSerializer(customers.GetType(), new XmlRootAttribute("Customers"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().Trim();
        }
    }
}