namespace _02.AdvertisementMessage
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AdvertisementMessage
    {
        static void Main()
        {
            List<string> phrases = new List<string>() {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            List<string> events = new List<string>()
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            List<string> authors = new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            List<string> cities = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            StringBuilder sb = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int number = rand.Next(0, phrases.Count);
                string phrase = phrases[number];

                number = rand.Next(0, events.Count);
                string eventMSG = events[number];

                number = rand.Next(0, authors.Count);
                string author = authors[number];

                number = rand.Next(0, cities.Count);
                string city = cities[number];

                sb.AppendLine($"{phrase} {eventMSG} {author} – {city}.");

                Console.WriteLine(sb.ToString());
                sb.Clear();
            }

        }
    }
}