    namespace _08.TradeComissions
    {
        using System;

        public class TradeComissions
        {
            static void Main()
            {
                string city = Console.ReadLine();
                var sells = double.Parse(Console.ReadLine());

                if (sells < 0)
                {
                    Console.WriteLine("error");
                    return;
                }

                if (city == "Sofia")
                {
                    if (sells <= 500)
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.05));
                    }
                    else if (sells <= 1000)
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.07));
                    }
                    else if (sells <= 10000)
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.08));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.12));
                    }
                }
                else if (city == "Varna")
                {
                    if (sells <= 500)
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.045));
                    }
                    else if (sells <= 1000)
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.075));
                    }
                    else if (sells <= 10000)
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.10));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.13));
                    }
                }
                else if (city == "Plovdiv")
                {
                    if (sells <= 500)
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.055));
                    }
                    else if (sells <= 1000)
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.08));
                    }
                    else if (sells <= 10000)
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.12));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("{0:F2}", sells * 0.145));
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
        }
    }
