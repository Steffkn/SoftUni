namespace HTTPServer.GameStoreApplication.Utilities
{
    using HTTPServer.GameStoreApplication.Models;
    using HTTPServer.Server.Common;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Templates
    {
        public static string FillTemplate(string templateFilePath, IDictionary<string, string> values)
        {
            var file = File.ReadAllText(string.Format(
                    ApplicationSettings.DefaultPath,
                    ApplicationSettings.ProjectName,
                    templateFilePath));

            foreach (var kvp in values)
            {
                file = file.Replace($"{{{{{{{kvp.Key}}}}}}}", kvp.Value);
            }

            return file;
        }

        public static string GenerateGameCards(string templateFilePath, List<GameInfo> games)
        {
            var builder = new StringBuilder();
            string result = string.Empty;
            int count = 0;
            foreach (var game in games)
            {
                count++;
                var values = new Dictionary<string, string>();
                values.Add("id", game.Id.ToString());
                values.Add("ytVideo", game.Trailer);
                values.Add("imageUrl", game.Image);
                values.Add("title", game.Title);
                values.Add("price", game.Price.ToString("F2"));
                values.Add("size", game.SizeGB);
                values.Add("description", game.Description.Substring(0, Math.Min(game.Description.Length, 300)));
                result += Templates.FillTemplate(templateFilePath, values);
                if (count == 3)
                {
                    builder.AppendFormat("<div class=\"card-group\">{0}</div>", result);
                    result = string.Empty;
                }
            }

            if (!string.IsNullOrEmpty(result))
            {
                builder.AppendFormat("<div class=\"card-group\">{0}</div>", result);
            }

            return builder.ToString();
        }

        public static string GenerateGamesInCarts(string templateFilePath, List<GameInfo> games)
        {
            var builder = new StringBuilder();
            string result = string.Empty;
            foreach (var game in games)
            {
                var values = new Dictionary<string, string>();
                values.Add("id", game.Id.ToString());
                values.Add("ytVideo", game.Trailer);
                values.Add("title", game.Title);
                values.Add("price", game.Price.ToString("F2"));
                values.Add("description", game.Description.Substring(0, Math.Min(game.Description.Length, 300)));
                result = Templates.FillTemplate(templateFilePath, values);
                builder.Append(result);
            }

            return builder.ToString();
        }

    }
}
