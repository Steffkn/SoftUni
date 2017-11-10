namespace _02.Ladybugs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Ladybugs
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugIndexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] field = new int[fieldSize];

            for (int i = 0; i < ladybugIndexes.Length; i++)
            {
                if (ladybugIndexes[i] < fieldSize && ladybugIndexes[i] >= 0)
                {
                    field[ladybugIndexes[i]] = 1;
                }
            }

            var commands = new List<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("end"))
                {
                    break;
                }

                var args = input.Split();
                var ladybugIndex = int.Parse(args[0]);

                if (ladybugIndex >= 0 && ladybugIndex < fieldSize)
                {
                    if (field[ladybugIndex] == 1)
                    {
                        var direction = args[1];
                        var moveLenght = int.Parse(args[2]);

                        if (direction.Equals("left"))
                        {
                            moveLenght *= -1;
                        }

                        field[ladybugIndex] = 0;

                        long newPosition = ladybugIndex + moveLenght;

                        while (true)
                        {
                            if (newPosition >= 0 && newPosition < field.Length)
                            {
                                if (field[newPosition] == 1)
                                {
                                    newPosition += moveLenght;
                                }
                                else
                                {
                                    field[newPosition] = 1;
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(" ", field));
        }
    }
}
