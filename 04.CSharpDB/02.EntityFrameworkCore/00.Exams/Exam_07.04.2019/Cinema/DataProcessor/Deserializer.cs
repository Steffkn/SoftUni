namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializationResult = JsonConvert.DeserializeObject<MovieImportDTO[]>(jsonString);
            var movies = new List<Movie>();

            foreach (var result in deserializationResult)
            {
                var movie = Mapper.Map<Movie>(result);

                if (IsValid(movie))
                {
                    sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre.ToString(), movie.Rating.ToString("F2")));
                    movies.Add(movie);
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            Console.WriteLine(sb);

            context.Movies.AddRange(movies);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializationResult = JsonConvert.DeserializeObject<HallSeatsImportDTO[]>(jsonString);
            var halls = new List<Hall>();

            foreach (var result in deserializationResult)
            {
                var hall = Mapper.Map<Hall>(result);

                for (int i = 0; i < result.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                if (IsValid(hall))
                {
                    if (hall.Seats.Count < 1)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    halls.Add(hall);
                    
                    string projectionType = string.Empty;

                    if (hall.Is3D == true && hall.Is4Dx == true)
                    {
                        projectionType = "4Dx/3D";
                    }
                    else if (hall.Is3D == true)
                    {
                        projectionType = "3D";
                    }
                    else if (hall.Is4Dx == true)
                    {
                        projectionType = "4Dx";
                    }
                    else
                    {
                        projectionType = "Normal";
                    }

                    sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            Console.WriteLine(sb.ToString());

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ProjectionImportDTO[]), new XmlRootAttribute("Projections"));
            var deserializationResult = (ProjectionImportDTO[])serializer.Deserialize(new StringReader(xmlString));
            var projections = new List<Projection>();

            foreach (var result in deserializationResult)
            {
                var projection = Mapper.Map<Projection>(result);

                if (IsValid(projection) && context.Halls.Any(h => h.Id == projection.HallId) && context.Movies.Any(m => m.Id == projection.MovieId))
                {
                    sb.AppendLine(string.Format(SuccessfulImportProjection, context.Movies.First(m => m.Id == projection.MovieId).Title, projection.DateTime.ToString("MM/dd/yyyy")));

                    projections.Add(projection);
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(CustomerImportDTO[]), new XmlRootAttribute("Customers"));
            var customers = new List<Customer>();

            var deserializationResult = (CustomerImportDTO[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var result in deserializationResult)
            {
                var customer = new Customer()
                {
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Age = result.Age,
                    Balance = result.Balance
                };

                foreach (var ticketResult in result.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticketResult.ProjectionId,
                        Price = ticketResult.Price
                    });
                }

                if (IsValid(customer))
                {
                    sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));

                    customers.Add(customer);
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}