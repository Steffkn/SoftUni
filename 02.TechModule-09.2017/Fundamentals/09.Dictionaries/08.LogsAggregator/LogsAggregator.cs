namespace _08.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsAggregator
    {
        static void Main()
        {
            // user, {IPS, duration}
            var users = new SortedDictionary<string, SortedDictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                if (!users.ContainsKey(input[1]))
                {
                    users.Add(input[1], new SortedDictionary<string, int>());
                }

                if (!users[input[1]].ContainsKey(input[0]))
                {
                    users[input[1]].Add(input[0], int.Parse(input[2]));
                }
                else
                {
                    users[input[1]][input[0]] += int.Parse(input[2]);
                }
            }

            foreach (var item in users.Keys)
            {
                var totalDuration = users[item].Values.Sum();
                var ips = String.Join(", ", users[item].Keys);

                Console.WriteLine($"{item}: {totalDuration} [{ips}]");
            }
        }
    }
}