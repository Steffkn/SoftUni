namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count > 0))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("F2"),
                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = m.Projections
                        .SelectMany(p => p.Tickets
                            .Select(t => new
                            {
                                FirstName = t.Customer.FirstName,
                                LastName = t.Customer.LastName,
                                Balance = t.Customer.Balance.ToString("F2")
                            }))
                            .OrderByDescending(c => c.Balance)
                            .ThenBy(c => c.FirstName)
                            .ThenBy(c => c.LastName)
                            .ToArray()
                })
                .OrderByDescending(m => double.Parse(m.Rating))
                .ThenByDescending(m => decimal.Parse(m.TotalIncomes))
                .Take(10)
                .ToArray();

            var result = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return result;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(c => c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                .Select(c => new CustomerExportDTO
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpendMoney = c.Tickets.Sum(t => t.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromTicks(c.Tickets.Sum(t => t.Projection.Movie.Duration.Ticks)).ToString(@"hh\:mm\:ss")
                })
                
                .Take(10)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CustomerExportDTO[]), new XmlRootAttribute("Customers"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), customers, namespaces);

            return result.ToString().TrimEnd();
        }
    }
}