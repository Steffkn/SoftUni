namespace _06.UserLogs
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class UserLogs
    {
        static void Main()
        {
            // name, {IP, count}
            var hackers = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (input[0] == "end")
                {
                    foreach (var hacker in hackers.Keys)
                    {
                        Console.WriteLine($"{hacker}: ");

                        string result = string.Empty;

                        foreach (var hackerIP in hackers[hacker].Keys)
                        {
                            result += $"{hackerIP} => {hackers[hacker][hackerIP]}, ";
                        }

                        Console.WriteLine(result.Remove(result.Length - 2) + ".");
                    }

                    break;
                }

                var name = input[2].Replace("user=", "");
                var ip = input[0].Replace("IP=", "");

                if (!hackers.ContainsKey(name))
                {
                    hackers.Add(name, new Dictionary<string, int>());
                }

                if (!hackers[name].ContainsKey(ip))
                {
                    hackers[name].Add(ip, 1);
                }
                else
                {
                    hackers[name][ip] += 1;
                }
            }
        }
    }
}