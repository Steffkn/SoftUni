namespace _07.MetricConverter
{
    using System;

    public class MetricConverter
    {
        static void Main()
        {
            var number = double.Parse(Console.ReadLine());

            string from = Console.ReadLine();
            string to = Console.ReadLine();

            double resultInMeters = 0;

            switch (from)
            {
                case "m":
                    resultInMeters = number;
                    break;

                case "mm":
                    resultInMeters = number / 1000;
                    break;

                case "cm":
                    resultInMeters = number / 100;
                    break;

                case "km":
                    resultInMeters = number / 0.001;
                    break;

                case "mi":
                    resultInMeters = number / 0.000621371192;
                    break;

                case "in":
                    resultInMeters = number / 39.3700787;
                    break;

                case "ft":
                    resultInMeters = number / 3.2808399;
                    break;

                case "yd":
                    resultInMeters = number / 1.0936133;
                    break;

                default:
                    break;
            }

            double result = 0;

            switch (to)
            {
                case "m":
                    result = resultInMeters;
                    break;

                case "mm":
                    result = resultInMeters * 1000;
                    break;

                case "cm":
                    result = resultInMeters * 100;
                    break;

                case "km":
                    result = resultInMeters * 0.001;
                    break;

                case "mi":
                    result = resultInMeters * 0.000621371192;
                    break;

                case "in":
                    result = resultInMeters * 39.3700787;
                    break;

                case "ft":
                    result = resultInMeters * 3.2808399;
                    break;

                case "yd":
                    result = resultInMeters * 1.0936133;
                    break;

                default:
                    break;
            }

            Console.WriteLine(string.Format("{0:F8}", result));
        }
    }
}
