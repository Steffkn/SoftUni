namespace _01.Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal totalLoss = 0;
            var sites = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string siteName = input[0];
                long siteVisits = long.Parse(input[1]);
                decimal siteCommersialPricePerVisit = decimal.Parse(input[2]);

                sites.Add(siteName);
                totalLoss += (siteVisits * siteCommersialPricePerVisit);
            }

            foreach (var site in sites)
            {
                Console.WriteLine(site);
            }

            BigInteger securityToken = BigInteger.Pow(securityKey, n);

            Console.WriteLine($"Total Loss: {totalLoss:F20}");
            Console.WriteLine($"Security Token: {securityToken}");
        }
    }
}
