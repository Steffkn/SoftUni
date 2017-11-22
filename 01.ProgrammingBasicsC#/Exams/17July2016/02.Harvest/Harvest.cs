namespace _02.Harvest
{
    using System;

    public class Harvest
    {
        static void Main()
        {
            var areaField = int.Parse(Console.ReadLine());
            var grapeFrom1SquareM = double.Parse(Console.ReadLine());
            var requiredLitersWine = int.Parse(Console.ReadLine());
            var numberOfWorkers = int.Parse(Console.ReadLine());

            var fieldAreaForWine = areaField * 40 / 100;
            var grapeFromTheField = fieldAreaForWine * grapeFrom1SquareM;
            var litersOfWineFromField = grapeFromTheField / 2.5;

            if (requiredLitersWine > litersOfWineFromField)
            {
                Console.WriteLine(string.Format("It will be a tough winter! More {0} liters wine needed.", Math.Floor(requiredLitersWine - litersOfWineFromField)));
            }
            else
            {
                var reminder = litersOfWineFromField - requiredLitersWine;
                Console.WriteLine(string.Format("Good harvest this year! Total wine: {0} liters.", Math.Floor(litersOfWineFromField)));
                Console.WriteLine(string.Format("{0} liters left -> {1} liters per person.", Math.Ceiling(reminder), Math.Ceiling(reminder / numberOfWorkers)));
            }
        }
    }
}
