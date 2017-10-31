namespace _09.MelrahShake
{
    using System;

    public class MelrahShake
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                int indexOfPatter = input.IndexOf(pattern);
                int lastIndexOfPatter = input.LastIndexOf(pattern);

                if ((indexOfPatter == -1 || lastIndexOfPatter == -1) 
                    || (indexOfPatter == lastIndexOfPatter))
                {
                    Console.WriteLine("No shake.");
                    break;
                }
                else
                {
                    Console.WriteLine("Shaked it.");
                    input = input.Remove(indexOfPatter, pattern.Length);
                    lastIndexOfPatter = input.LastIndexOf(pattern);
                    input = input.Remove(lastIndexOfPatter, pattern.Length);
                    pattern = pattern.Remove(pattern.Length / 2, 1);

                    if (pattern.Length == 0)
                    {
                        Console.WriteLine("No shake.");
                        break;
                    }
                    else if (pattern.Length * 2 > input.Length)
                    {
                        Console.WriteLine("No shake.");
                        break;
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}