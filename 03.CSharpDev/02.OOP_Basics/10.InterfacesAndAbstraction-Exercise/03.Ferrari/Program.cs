using System;

public class Program
{
    static void Main()
    {
        string driver = Console.ReadLine();

        ICar car = new Ferrari(driver);

        // 488-Spider/Brakes!/Zadu6avam sA!/Bat Giorgi
        Console.WriteLine(string.Format("{0}/{1}/{2}/{3}", car.Model, car.UseBreaks(), car.UseGasPedal(), car.Driver));
    }
}
