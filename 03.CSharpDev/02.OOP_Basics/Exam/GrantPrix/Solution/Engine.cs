using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    internal void Run()
    {
        while (!this.raceTower.IsRaceOver)
        {
            string[] commandArgs = Console.ReadLine().Split();
            string commandtype = commandArgs[0];
            List<string> methodArgs = commandArgs.Skip(1).ToList();

            switch (commandtype)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(methodArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    string result = this.raceTower.CompleteLaps(methodArgs);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(methodArgs);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(methodArgs);
                    break;
                default:
                    Console.WriteLine("INVALID COMMAND");
                    break;
            }
        }
    }
}
