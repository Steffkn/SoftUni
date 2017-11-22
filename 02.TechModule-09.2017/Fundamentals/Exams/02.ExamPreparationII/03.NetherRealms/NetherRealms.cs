namespace _03.NetherRealms
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class NetherRealms
    {
        static void Main()
        {
            var demons = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .OrderBy(x => x)
                .ToList();

            foreach (var demon in demons)
            {
                int demonHealth = CalculateHealth(demon);
                double damage = CalculateDamage(demon);
                Console.WriteLine($"{demon} - {demonHealth} health, {damage:F2} damage");
            }
        }

        private static double CalculateDamage(string demon)
        {
            double damage = 0;
            int balance = 0;
            var separators = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/*".ToCharArray();
            var numbers = demon.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            int index = -1;
            while (true)
            {
                index = demon.IndexOf('*', index + 1);
                if (index == -1)
                {
                    break;
                }

                balance += 1;
            }

            index = -1;
            while (true)
            {
                index = demon.IndexOf('/', index + 1);
                if (index == -1)
                {
                    break;
                }

                balance -= 1;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                double result = 0;
                var subNums = numbers[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                result = double.Parse(subNums[0]);

                if (numbers[i].StartsWith("-"))
                {
                    result = result * (-1);
                }

                for (int n = 1; n < subNums.Length; n++)
                {
                    result -= double.Parse(subNums[n]);
                }

                numbers[i] = result.ToString();
            }

            damage = numbers.Select(double.Parse).Sum();

            if (balance > 0)
            {
                damage = damage * (balance * 2);
            }
            else if (balance < 0)
            {
                damage = damage / (balance * (-2));
            }

            return damage;
        }

        private static int CalculateHealth(string demon)
        {
            int health = 0;
            foreach (var ch in demon)
            {
                if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z')
                {
                    health += (int)ch;
                }
            }

            return health;
        }
    }
}
