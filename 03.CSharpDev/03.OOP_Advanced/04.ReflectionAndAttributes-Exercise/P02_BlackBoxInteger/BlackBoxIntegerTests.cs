using System.Linq;

namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");
            var blackBoxInstance = Activator.CreateInstance(type, true);
            var innerValueField = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var commandArgs = input.Split('_');
                string command = commandArgs[0];
                int commandValue = int.Parse(commandArgs[1]);
                var methodToInvoke = type.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Instance);
                methodToInvoke.Invoke(blackBoxInstance, new object[] { commandValue });

                Console.WriteLine(innerValueField.GetValue(blackBoxInstance));
            }
        }
    }
}
