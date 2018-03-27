using P07.CustomList.Models;

namespace P07.CustomList
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = string.Empty;
            var list = new CustomList<string>();
            var commandInterpreter = new CommandInterpreter();
            while ((input = Console.ReadLine()) != "END")
            {
                commandInterpreter.InterpredCommand(input, list);
            }
        }
    }
}
