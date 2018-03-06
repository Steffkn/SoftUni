using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string input = string.Empty;
        var teams = new Dictionary<string, Team>();
        while ((input = Console.ReadLine()) != "END")
        {
            var commandArgs = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var command = commandArgs[0];
            var teamName = commandArgs[1];

            try
            {
                if (command != "Team")
                {
                    Validator.ValidateTeamNameExists(teamName, teams);
                }

                switch (command)
                {
                    case "Team":
                        if (!teams.ContainsKey(teamName))
                        {
                            teams[teamName] = new Team(commandArgs[1]);
                        }
                        break;
                    case "Add":
                        var stats = commandArgs.Skip(3).Take(5).Select(int.Parse).ToArray();
                        teams[teamName].AddPlayer(new Player(commandArgs[2], stats));
                        break;
                    case "Remove":
                        Validator.ValidatePlayerExists(teamName, commandArgs[2], teams[teamName]);
                        teams[teamName].RemovePlayer(commandArgs[2]);
                        break;
                    case "Rating":
                        Console.WriteLine(teams[teamName]);
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
