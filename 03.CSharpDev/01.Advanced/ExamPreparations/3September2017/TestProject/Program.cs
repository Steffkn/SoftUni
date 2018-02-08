using System;

public class Program
{
    static void Main()
    {
        var aa = new int[10][];

        var one = new int[] { 0 };
        var two = new int[] { 0, 1 };
        var tree = new int[] { 0, 1, 2 };
        var four = new int[] { 0, 1, 2, 3 };
        var five = new int[] { 0, 1, 2, 3, 4 };
        var six = new int[] { 0, 1, 2, 3, 4, 5 };
        var sev = new int[] { 0, 1, 2, 3, 4, 5, 6, };
        var eig = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, };
        var nine = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, };
        var ten = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, };

        aa[0] = one;
        aa[1] = two;
        aa[2] = tree;
        aa[3] = four;
        aa[4] = five;
        aa[5] = six;
        aa[6] = sev;
        aa[7] = eig;
        aa[8] = nine;
        aa[9] = ten;

        int count = 1;
        foreach (var i in aa)
        {
            Console.WriteLine($"{count} - {i.Length / 2}");
            count++;
        }
    }
}
