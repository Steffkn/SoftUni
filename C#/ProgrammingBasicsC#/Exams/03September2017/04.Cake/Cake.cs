namespace _04.Cake
{
    using System;

    public class Cake
    {
        static void Main()
        {
            var cakeL = int.Parse(Console.ReadLine());
            var cakeW = int.Parse(Console.ReadLine());

            var cakePeaces = cakeL * cakeW;

            while (cakePeaces >= 0)
            {
                string input = Console.ReadLine();
                if (input.ToLower() != "stop")
                {
                    var takePeaces = int.Parse(input);

                    if (cakePeaces >= takePeaces)
                    {
                        cakePeaces -= takePeaces;
                    }
                    else
                    {
                        Console.WriteLine(string.Format("No more cake left! You need {0} pieces more.", takePeaces - cakePeaces));
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("{0} pieces are left.", cakePeaces));

                    break;
                }
            }
        }
    }
}
