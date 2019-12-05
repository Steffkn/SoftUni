namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.ExportDTO;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .OrderByDescending(g => g.Games.Where(t => t.Purchases.Count > 0).Sum(game => game.Purchases.Count))
                .ThenBy(g => g.Id)
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(game => game.Purchases.Count > 0)
                        .Select(game => new
                        {
                            Id = game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = string.Join(", ", game.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                            Players = game.Purchases.Count
                        })
                        .OrderByDescending(game => game.Players)
                        .ThenBy(game => game.Id)
                        .ToArray(),
                    TotalPlayers = g.Games
                        .Where(game => game.Purchases.Count > 0)
                        .Sum(game => game.Purchases.Count)
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(games);

            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var sb = new StringBuilder();

            var users = context.Users
                .Select(user => new UserExportDTO
                {
                    Username = user.Username,
                    Purchases = user.Cards.SelectMany(p => p.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Select(p => new PurchaseExportDTO
                    {
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString(@"yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Card = p.Card.Number,
                        Game = new GameExportDTO
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .OrderBy(p => p.Date)
                    .ToArray(),
                    TotalSpent = user.Cards.SelectMany(c => c.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Sum(p => p.Game.Price)                    
                })
                .Where(p => p.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();


            var serializer = new XmlSerializer(typeof(UserExportDTO[]), new XmlRootAttribute("Users"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}