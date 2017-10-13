namespace _10.CubeProperties
{
    using System;

    public class CubeProperties
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            string function = Console.ReadLine().ToLower().Trim();

            double result = GetCubeProperty(a, function);

            Console.WriteLine("{0:F2}",result);
        }

        private static double GetCubeProperty(double a, string function)
        {
            double result = 0;
            switch (function)
            {
                case "face":
                    result = Math.Sqrt(2 * a * a);
                    break;
                case "space":
                    result = Math.Sqrt(3 * a * a);
                    break;
                case "volume":
                    result = a * a * a;
                    break;
                case "area":
                    result = 6 * a * a;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
