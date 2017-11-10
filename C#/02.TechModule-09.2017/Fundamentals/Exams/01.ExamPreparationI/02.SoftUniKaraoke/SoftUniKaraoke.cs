namespace _02.SoftUniKaraoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniKaraoke
    {
        static void Main()
        {
            var recordedSingers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var availableSongs = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            var singers = new Dictionary<string, Singer>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input.Equals("dawn"))
                {
                    break;
                }

                var inputs = input
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                string singer = inputs[0];
                string song = inputs[1];
                string award = inputs[2];

                if (recordedSingers.Contains(singer) && availableSongs.Contains(song))
                {
                    if (!singers.ContainsKey(singer))
                    {
                        singers.Add(singer, new Singer(singer));
                    }

                    if (!singers[singer].Awards.Contains(award))
                    {
                        singers[singer].Awards.Add(award);
                    }
                }
            }

            if (singers.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                foreach (var singer in singers.OrderByDescending(x => x.Value.Awards.Count)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{singer.Key}: {singer.Value.Awards.Count} awards");

                    foreach (var award in singer.Value.Awards.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
        }

        class Singer
        {
            public string name;
            public List<string> Awards = new List<string>();

            public Singer(string name)
            {
                this.name = name;
            }
        }
    }
}
