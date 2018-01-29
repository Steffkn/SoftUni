namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;

    public class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long truckPetrol = 0;
            int pumpIndex = 0;
            var petrolQueue = new Queue<long>();

            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                petrolQueue.Enqueue(long.Parse(inputs[0]) - long.Parse(inputs[1]));
            }

            bool indexFound = false;
            while (!indexFound)
            {
                indexFound = true;
                while (petrolQueue.Peek() < 0)
                {
                    petrolQueue.Enqueue(petrolQueue.Dequeue());
                    pumpIndex++;
                }

                for (int i = 0; i < n; i++)
                {
                    long number = petrolQueue.Dequeue();
                    truckPetrol += number;
                    petrolQueue.Enqueue(number);
                    if (truckPetrol < 0)
                    {
                        indexFound = false;
                        pumpIndex += i + 1;
                        truckPetrol = 0;
                        break;
                    }
                }
            }

            Console.WriteLine(pumpIndex % n);
        }
    }
}
