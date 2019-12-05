namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDTO;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializationResult = JsonConvert.DeserializeObject<GameImportDTO[]>(jsonString);

            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();
            List<Game> games = new List<Game>();

            foreach (var result in deserializationResult)
            {
                if (!IsValid(result))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Developer developer;
                Genre genre;
                Game game;
                List<Tag> gameTags = new List<Tag>();

                if (developers.FirstOrDefault(d => d.Name == result.Developer) != null)
                {
                    developer = developers.FirstOrDefault(d => d.Name == result.Developer);
                }
                else
                {
                    developer = new Developer() { Name = result.Developer };
                    developers.Add(developer);
                }

                if (genres.FirstOrDefault(g => g.Name == result.Genre) != null)
                {
                    genre = genres.FirstOrDefault(g => g.Name == result.Genre);
                }
                else
                {
                    genre = new Genre() { Name = result.Genre };
                    genres.Add(genre);
                }

                foreach (var tag in result.Tags)
                {
                    if (tags.FirstOrDefault(t => t.Name == tag) != null)
                    {
                        gameTags.Add(tags.FirstOrDefault(t => t.Name == tag));
                    }
                    else
                    {
                        var newTag = new Tag() { Name = tag };
                        tags.Add(newTag);
                        gameTags.Add(newTag);
                    }
                }

                game = new Game()
                {
                    Name = result.Name,
                    Developer = developer,
                    Genre = genre,
                    Price = result.Price,
                    ReleaseDate = DateTime.ParseExact(result.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    GameTags = gameTags.Select(tg => new GameTag() { Tag = tg }).ToList()
                };

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializationResult = JsonConvert.DeserializeObject<UserImportDTO[]>(jsonString);
            var users = new List<User>();

            foreach (var result in deserializationResult)
            {
                var cards = result.Cards
                    .Select(c => new Card
                    {
                        Number = c.Number,
                        Cvc = c.CVC,
                        Type = (CardType)Enum.Parse(typeof(CardType), c.Type, true)
                    })
                    .ToArray();

                var user = new User()
                {
                    FullName = result.FullName,
                    Username = result.Username,
                    Email = result.Email,
                    Age = result.Age,
                    Cards = cards
                };

                bool isValidUser = IsValid(user);
                bool areValidCards = cards.All(c => IsValid(c));

                if (isValidUser && areValidCards)
                {
                    sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
                    users.Add(user);
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(PurchaseImportDTO[]), new XmlRootAttribute("Purchases"));
            var deserializationResult = (PurchaseImportDTO[])serializer.Deserialize(new StringReader(xmlString));
            var purchases = new List<Purchase>();

            foreach (var dto in deserializationResult)
            {
                var type = (PurchaseType)Enum.Parse(typeof(PurchaseType), dto.Type);
                var card = context.Cards.FirstOrDefault(c => c.Number == dto.Card);
                var date = DateTime.ParseExact(dto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var game = context.Games.FirstOrDefault(g => g.Name == dto.Title);


                var purchase = new Purchase()
                {
                    Type = type,
                    ProductKey = dto.Key,
                    Date = date,
                    Card = card,
                    Game = game
                };

                if (IsValid(purchase))
                {
                    purchases.Add(purchase);
                    sb.AppendLine($"Imported {game.Name} for {card.User.Username}");
                }
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, result, true);
        }
    }
}