namespace _04.CharacterMultiplier
{
    using System;

    public class CharacterMultiplier
    {
        static void Main()
        {
            var inputs = Console.ReadLine().Split(' ');

            string stringA = inputs[0];
            string stringB = inputs[1];

            long result = Multiply(stringA, stringB);

            Console.WriteLine(result);
        }

        private static long Multiply(string stringA, string stringB)
        {
            long result = 0;
            int aLenght = stringA.Length;
            int bLenght = stringB.Length;

            if (aLenght > bLenght)
            {
                for (int i = 0; i < bLenght; i++)
                {
                    result += (int)stringA[i] * (int)stringB[i];
                }

                for (int i = bLenght; i < aLenght; i++)
                {
                    result += (int)stringA[i];
                }
            }
            else
            {
                for (int i = 0; i < aLenght; i++)
                {
                    result += (int)stringA[i] * (int)stringB[i];
                }

                for (int i = aLenght; i < bLenght; i++)
                {
                    result += (int)stringB[i];
                }
            }

            return result;
        }
    }
}