using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class Program
{
    static void Main()
    {
        string input = string.Empty;
        var soldiers = new Dictionary<string, ISoldier>();

        while ((input = Console.ReadLine()) != "End")
        {
            var soldierArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (soldierArgs[0])
            {
                case "Private":
                    soldiers.Add(soldierArgs[1], new Private(soldierArgs[1], soldierArgs[2], soldierArgs[3], double.Parse(soldierArgs[4])));
                    break;
                case "LeutenantGeneral":
                    var privateIds = soldierArgs.Skip(5);
                    var privateList = new List<IPrivate>();
                    foreach (string privateId in privateIds)
                    {
                        if (!soldiers.ContainsKey(privateId) && (soldiers[privateId] is IPrivate))
                        {
                            privateList.Add((Private)soldiers[privateId]);
                        }
                    }

                    soldiers.Add(soldierArgs[1], new LeutenantGeneral(soldierArgs[1], soldierArgs[2], soldierArgs[3], double.Parse(soldierArgs[4]), privateList));
                    break;
                case "Engineer":
                    var corps = soldierArgs[5];
                    if (corps != "Airforces" && corps != "Marines")
                    {
                        continue;
                    }

                    var partsList = new List<Part>();
                    string[] parts = soldierArgs.Skip(6).ToArray();

                    for (int i = 0; i < parts.Count(); i += 2)
                    {
                        partsList.Add(new Part(parts[i], int.Parse(parts[i + 1])));
                    }

                    soldiers.Add(soldierArgs[1], new Engineer(soldierArgs[1], soldierArgs[2], soldierArgs[3], double.Parse(soldierArgs[4]), corps, partsList));
                    break;
                case "Commando":
                    var corpus = soldierArgs[5];
                    if (corpus != "Airforces" && corpus != "Marines")
                    {
                        continue;
                    }

                    var missionsList = new List<Mission>();

                    string[] missionsArgs = soldierArgs.Skip(6).ToArray();

                    for (int i = 0; i < missionsArgs.Count(); i += 2)
                    {
                        var missiontState = missionsArgs[i + 1];
                        if (missiontState == "inProgress" || missiontState == "Finished")
                        {
                            missionsList.Add(new Mission(missionsArgs[i], missionsArgs[i + 1]));
                        }
                    }

                    soldiers.Add(soldierArgs[1], new Commando(soldierArgs[1], soldierArgs[2], soldierArgs[3], double.Parse(soldierArgs[4]), corpus, missionsList));
                    break;
                case "Spy":
                    soldiers.Add(soldierArgs[1], new Spy(soldierArgs[1], soldierArgs[2], soldierArgs[3], soldierArgs[4]));
                    break;
            }
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier.Value);
        }
    }
}
