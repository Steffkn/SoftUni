using System;
using System.Linq;

public class CryptoMaster
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int result = 0;

        for (int currentLenght = 1; currentLenght < numbers.Length; currentLenght++)
        {
            for (int startIndex = 0; startIndex < numbers.Length; startIndex++)
            {
                int currentIndex = startIndex;
                int nextIndex = (currentIndex + currentLenght) % numbers.Length;
                int count = 1;

                while (numbers[currentIndex] < numbers[nextIndex])
                {
                    count++;
                    currentIndex = nextIndex;
                    nextIndex = (currentIndex + currentLenght) % numbers.Length;
                }

                if (result < count)
                {
                    result = count;
                }
            }
        }

        Console.WriteLine(result);
    }
}
