    namespace _13.AreaOfFigures
    {
        using System;

        public class AreaOfFigures
        {
            static void Main()
            {
                string figure = Console.ReadLine();

                switch (figure)
                {
                    case "square":
                        double side = double.Parse(Console.ReadLine());
                        Console.WriteLine(side * side);
                        break;

                    case "rectangle":
                        double sideA = double.Parse(Console.ReadLine());
                        double sideB = double.Parse(Console.ReadLine());
                        Console.WriteLine(sideA * sideB);
                        break;

                    case "circle":
                        double r = double.Parse(Console.ReadLine());
                        Console.WriteLine(Math.PI * r * r);
                        break;
                    case "triangle":
                        double A = double.Parse(Console.ReadLine());
                        double CH = double.Parse(Console.ReadLine());
                        Console.WriteLine((A * CH) / 2);
                        break;
                    default:
                        break;
                }
            }
        }
    }
