using System;
using System.Collections.Generic;
using System.Linq;

public class KeyRevolver
{
    static void Main()
    {
        int bulletPrise = int.Parse(Console.ReadLine());
        int barrelSize = int.Parse(Console.ReadLine());
        var bullets = new Stack<int>(
            Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            );
        var locks = new Queue<int>(
            Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            );
        int intelValue = int.Parse(Console.ReadLine());
        int bulletsFired = 0;

        for (int i = 0, j = barrelSize - 1; bullets.Count > 0; i++, j--)
        {
            if (bullets.Peek() <= locks.Peek())
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            bulletsFired++;
            bullets.Pop();

            if (j == 0 && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
                j = barrelSize;
            }

            if (locks.Count == 0)
            {
                break;
            }
        }

        if (locks.Count == 0)
        {
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelValue - (bulletPrise * bulletsFired)}");
        }
        else
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
