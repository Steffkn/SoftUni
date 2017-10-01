namespace _02.SoftUniKaraoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniKaraoke
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> singers = new List<string>();
            List<string> songs = new List<string>();
            Dictionary<string, int> result = new Dictionary<string, int>();
            List<string> awards = new List<string>();

            foreach (var item in input)
            {
                singers.Add(item.Trim());
            }

            input = Console.ReadLine().Split(new char[] { ',', }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                songs.Add(item.Trim());
            }

            singers.Sort();

            foreach (var item in singers)
            {
                Console.WriteLine(item);
            }

            while (true)
            {
                string lineInput = Console.ReadLine();

                if (lineInput == "dawn")
                {
                    //result.OrderBy(r => r.Key);

                    int i = 0;
                    foreach (var singer in result)
                    {
                        Console.WriteLine($"{singer.Key}: {singer.Value} awards");
                        string[] singersAwards = awards[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var award in singersAwards)
                        {
                            Console.WriteLine($"--{award}");
                        }
                    }

                    break;
                }

                string[] data = lineInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < singers.Count; i++)
                {
                    if (data[0].Trim() == singers[i])
                    {
                        foreach (var song in songs)
                        {
                            if (data[1].Trim() == song)
                            {
                                if (result.ContainsKey(singers[i]))
                                {
                                    result[singers[i]]++;
                                    awards[i] += data[2].Trim() + ",";
                                }
                                else
                                {
                                    result.Add(singers[i], 1);
                                    awards.Add(data[2].Trim());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
