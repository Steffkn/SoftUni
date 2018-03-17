using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        int numberOfLaps = int.Parse(Console.ReadLine());
        int trackLenght = int.Parse(Console.ReadLine());
        var raceTower = new RaceTower();
        raceTower.SetTrackInfo(numberOfLaps, trackLenght);
        while (numberOfLaps > raceTower.completedLapsnumber)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = input[0];
            try
            {
                switch (command)
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(input.Skip(1).ToList());
                        break;
                    case "Leaderboard":
                        Console.WriteLine(raceTower.GetLeaderboard());
                        break;
                    case "CompleteLaps":
                        var result = raceTower.CompleteLaps(input.Skip(1).ToList());
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            Console.WriteLine(result);
                        }
                        break;
                    case "Box":
                        raceTower.DriverBoxes(input.Skip(1).ToList());
                        break;
                    case "ChangeWeather":
                        raceTower.ChangeWeather(input.Skip(1).ToList());
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine(raceTower.PrintWinner());
    }
}
