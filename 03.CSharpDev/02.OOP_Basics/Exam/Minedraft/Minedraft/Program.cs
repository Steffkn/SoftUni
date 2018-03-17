using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        var input = string.Empty;
        var draftManager = new DraftManager();

        while ((input = Console.ReadLine()) != "Shutdown")
        {
            var args = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = args[0];
            string result = string.Empty;
            switch (command)
            {
                case "RegisterHarvester":
                    result = draftManager.RegisterHarvester(args.Skip(1).ToList());
                    break;
                case "RegisterProvider":
                    result = draftManager.RegisterProvider(args.Skip(1).ToList());
                    break;
                case "Day":
                    result = draftManager.Day();
                    break;
                case "Mode":
                    result = draftManager.Mode(args.Skip(1).ToList());
                    break;
                case "Check":
                    result = draftManager.Check(args.Skip(1).ToList());
                    break;
            }

            Console.WriteLine(result);
        }

        Console.WriteLine(draftManager.ShutDown());
    }
}
