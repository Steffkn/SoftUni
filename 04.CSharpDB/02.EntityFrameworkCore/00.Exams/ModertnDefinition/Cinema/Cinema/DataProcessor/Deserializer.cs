namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
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
        private const string ProjectionDateTimeFormat = "MM/dd/yyyy";

        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var res = Validator.TryValidateObject(obj, validator, validationResult, true);

            return res;
        }

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var deserializedObjects = JsonConvert.DeserializeObject<List<Movie>>(jsonString, serializerSettings);

            List<Movie> movies = new List<Movie>();
            var sb = new StringBuilder();

            foreach (var obj in deserializedObjects)
            {
                if (IsValid(obj))
                {
                    if (movies.Any(m => m.Title == obj.Title))
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                    else
                    {
                        movies.Add(obj);
                        sb.AppendFormat(SuccessfulImportMovie, obj.Title, obj.Genre.ToString(), obj.Rating.ToString("f2"));
                        sb.AppendLine();
                    }
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var deserializedObjects = JsonConvert.DeserializeObject<List<HallDTO>>(jsonString, serializerSettings);

            var halls = new List<Hall>();
            var sb = new StringBuilder();

            foreach (var obj in deserializedObjects)
            {
                var hall = Mapper.Map<Hall>(obj);
                if (IsValid(hall) && obj.Seats > 0)
                {
                    hall.Seats = new HashSet<Seat>();

                    for (int i = 0; i < obj.Seats; i++)
                    {
                        var seat = new Seat() { Hall = hall };
                        hall.Seats.Add(seat);
                    }

                    var projectionTypes = new List<string>();

                    if (obj.Is4Dx)
                    {
                        projectionTypes.Add("4Dx");
                    }
                    if (obj.Is3D)
                    {
                        projectionTypes.Add("3D");
                    }
                    if (projectionTypes.Count == 0)
                    {
                        projectionTypes.Add("Normal");
                    }

                    sb.AppendFormat(SuccessfulImportHallSeat, obj.Name, string.Join('/', projectionTypes), obj.Seats);
                    sb.AppendLine();
                    halls.Add(hall);
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProjectionDTO[]), new XmlRootAttribute("Projections"));
            var deserializationResult = (ProjectionDTO[])serializer.Deserialize(new StringReader(xmlString));

            var projections = new List<Projection>();
            var sb = new StringBuilder();

            foreach (var entity in deserializationResult)
            {
                var projection = Mapper.Map<Projection>(entity);

                if (IsValid(projection))
                {
                    var movie = context.Movies.FirstOrDefault(m => m.Id == projection.MovieId);
                    var hall = context.Halls.FirstOrDefault(h => h.Id == projection.HallId);

                    if (movie == null || hall == null)
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                    else
                    {
                        projections.Add(projection);
                        sb.AppendFormat(SuccessfulImportProjection, movie.Title, entity.DateTime.ToString(ProjectionDateTimeFormat, CultureInfo.InvariantCulture));
                        sb.AppendLine();
                    }
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
            var serializer = new XmlSerializer(typeof(CustomerDTO[]), new XmlRootAttribute("Customers"));
            var deserializationResult = (CustomerDTO[])serializer.Deserialize(new StringReader(xmlString));

            var customers = new List<Customer>();
            var sb = new StringBuilder();

            foreach (var entity in deserializationResult)
            {
                var customer = Mapper.Map<Customer>(entity);
                var tickets = Mapper.Map<Ticket[]>(customer.Tickets);
                if (IsValid(customer) && tickets.All(t => IsValid(t)))
                {
                    customer.Tickets = new HashSet<Ticket>(tickets);
                    customers.Add(customer);
                    sb.AppendFormat(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count);
                    sb.AppendLine();
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


        private static string Import<T>(CinemaContext context, string inputJson)
            where T : class
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var deserializedObjects = JsonConvert.DeserializeObject<List<T>>(inputJson, serializerSettings);
            context.Set<T>().AddRange(deserializedObjects);
            context.SaveChanges();
            return $"Successfully imported {deserializedObjects.Count}.";
        }

    }
}