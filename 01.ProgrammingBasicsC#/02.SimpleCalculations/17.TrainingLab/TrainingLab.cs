namespace _01.TrainingLab
{
    using System;

    public class TrainingLab
    {
        static void Main()
        {
            var w = double.Parse(Console.ReadLine()) * 100;
            var h = (double.Parse(Console.ReadLine()) - 1) * 100;
            var rows = (int)(w / 120);
            var cols = (int)(h / 70);

            Console.WriteLine(rows * cols - 3);
        }
    }
}