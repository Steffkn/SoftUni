namespace DungeonsAndCodeWizards
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var dungeonMaster = new DungeonMaster();
            while (!dungeonMaster.IsGameOver())
            {
                try
                {
                    var input = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(input))
                    {
                        break;
                    }

                    var commandArgs = input.Split();
                    var command = commandArgs[0];
                    switch (command)
                    {
                        case "JoinParty":
                            Console.WriteLine(dungeonMaster.JoinParty(commandArgs.Skip(1).ToArray()));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(dungeonMaster.AddItemToPool(commandArgs.Skip(1).ToArray()));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(dungeonMaster.PickUpItem(commandArgs.Skip(1).ToArray()));
                            break;
                        case "UseItem":
                            Console.WriteLine(dungeonMaster.UseItem(commandArgs.Skip(1).ToArray()));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(dungeonMaster.UseItemOn(commandArgs.Skip(1).ToArray()));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(dungeonMaster.GiveCharacterItem(commandArgs.Skip(1).ToArray()));
                            break;
                        case "GetStats":
                            Console.WriteLine(dungeonMaster.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(dungeonMaster.Attack(commandArgs.Skip(1).ToArray()));
                            break;
                        case "Heal":
                            Console.WriteLine(dungeonMaster.Heal(commandArgs.Skip(1).ToArray()));
                            break;
                        case "EndTurn":
                            Console.WriteLine(dungeonMaster.EndTurn(commandArgs.Skip(1).ToArray()));
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Parameter Error: {e.Message}");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"Invalid Operation: {e.Message}");
                }
                catch (Exception e)
                {
                    break;
                }
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }
    }
}
