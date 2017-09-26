namespace _15.NeighbourWars
{
    using System;

    public class NeighbourWars
    {
        static void Main()
        {
            int dmgPesho = int.Parse(Console.ReadLine());
            int dmgGosho = int.Parse(Console.ReadLine());

            int healthPesho = 100;
            int healthGosho = 100;
            int round = 0;

            // for loop with odd/even check should be better
            while (true)
            {
                round++;
                healthGosho = healthGosho - dmgPesho;
                if (healthGosho <= 0)
                {
                    Console.WriteLine($"Pesho won in {round}th round.");
                    return;
                }
                Console.WriteLine(string.Format("Pesho used Roundhouse kick and reduced Gosho to {0} health.", healthGosho));

                if (round % 3 == 0)
                {
                    healthGosho += 10;
                    healthPesho += 10;
                }

                round++;
                healthPesho = healthPesho - dmgGosho;
                if (healthPesho <= 0)
                {
                    Console.WriteLine($"Gosho won in {round}th round.");
                    return;
                }

                Console.WriteLine(string.Format("Gosho used Thunderous fist and reduced Pesho to {0} health.", healthPesho));

                if (round % 3 == 0)
                {
                    healthGosho += 10;
                    healthPesho += 10;
                }
            }

        }
    }
}