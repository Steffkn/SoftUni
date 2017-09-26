namespace _16.Number0_100ToText
{
    using System;

    public class Number0_100ToText
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            string spacer = " ";
            if (number < 100 && number > 0)
            {
                int unitsDigit = number % 10;
                int tensDigit = (int)(number / 10) % 10;

                switch (tensDigit)
                {
                    case 0:
                        spacer = string.Empty;
                        break;
                    case 1:
                        switch (unitsDigit)
                        {
                            case 0:
                                Console.WriteLine("ten");
                                return;
                            case 1:
                                Console.WriteLine("eleven");
                                return;
                            case 2:
                                Console.WriteLine("twelve");
                                return;
                            case 3:
                                Console.WriteLine("thirteen");
                                return;
                            case 4:
                                Console.WriteLine("fourteen");
                                return;
                            case 5:
                                Console.WriteLine("fifteen");
                                return;
                            case 6:
                                Console.WriteLine("sixteen");
                                return;
                            case 7:
                                Console.WriteLine("seventeen");
                                return;
                            case 8:
                                Console.WriteLine("eighteen");
                                return;
                            case 9:
                                Console.WriteLine("nineteen");
                                return;
                            default:
                                break;
                        }
                        break;

                    case 2:
                        Console.Write("twenty");
                        break;
                    case 3:
                        Console.Write("thirty");
                        break;
                    case 4:
                        Console.Write("forty");
                        break;
                    case 5:
                        Console.Write("fifty");
                        break;
                    case 6:
                        Console.Write("sixty");
                        break;
                    case 7:
                        Console.Write("seventy");
                        break;
                    case 8:
                        Console.Write("eighty");
                        break;
                    case 9:
                        Console.Write("ninety");
                        break;
                    default:
                        break;
                }

                switch (unitsDigit)
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine(spacer + "one");
                        break;
                    case 2:
                        Console.WriteLine(spacer + "two");
                        break;
                    case 3:
                        Console.WriteLine(spacer + "three");
                        break;
                    case 4:
                        Console.WriteLine(spacer + "four");
                        break;
                    case 5:
                        Console.WriteLine(spacer + "five");
                        break;
                    case 6:
                        Console.WriteLine(spacer + "six");
                        break;
                    case 7:
                        Console.WriteLine(spacer + "seven");
                        break;
                    case 8:
                        Console.WriteLine(spacer + "eight");
                        break;
                    case 9:
                        Console.WriteLine(spacer + "nine");
                        break;
                    default:
                        break;
                }
            }
            else if (number == 0)
            {
                Console.WriteLine("zero");
            }
            else if (number == 100)
            {
                Console.WriteLine("one hundred");
            }
            else
            {
                Console.WriteLine("invalid number");
            }

        }
    }
}
