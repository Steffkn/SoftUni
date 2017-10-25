namespace _07.AdvertisementMessage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class AdvertisementMessage
    {
        public const string inputFilePath = "input.txt";
        public const string outputFilePath = "output.txt";

        static void Main()
        {
            using (StreamWriter writer = File.CreateText(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(new FileStream(inputFilePath, FileMode.Open)))
                {
                    List<string> phrases = new List<string>() {
                        "Excellent product.",
                        "Such a great product.",
                        "I always use that product.",
                        "Best product of its category.",
                        "Exceptional product.",
                        "I can’t live without this product."
                    };

                    List<string> events = new List<string>(){
                        "Now I feel good.",
                        "I have succeeded with this product.",
                        "Makes miracles. I am happy of the results!",
                        "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.",
                        "I feel great!"
                    };

                    List<string> authors = new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

                    List<string> cities = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

                    while (!reader.EndOfStream)
                    {
                        int n = int.Parse(reader.ReadLine());
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

                            writer.WriteLine($"{phrase} {eventMSG} {author} – {city}.");
                        }
                    }
                }
            }
        }
    }
}