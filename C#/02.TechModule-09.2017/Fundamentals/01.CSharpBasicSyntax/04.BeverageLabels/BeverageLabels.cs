namespace _04.BeverageLabels
{
    using System;

    public class BeverageLabels
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyPer100ml = int.Parse(Console.ReadLine());
            int sugarPer100ml = int.Parse(Console.ReadLine());

            double totalEnergy = volume * energyPer100ml / 100.0;
            double totalSugars = volume * sugarPer100ml / 100.0;

            Console.WriteLine($"{volume}ml {name}:");
            Console.WriteLine($"{totalEnergy}kcal, {totalSugars}g sugars");
        }
    }
}