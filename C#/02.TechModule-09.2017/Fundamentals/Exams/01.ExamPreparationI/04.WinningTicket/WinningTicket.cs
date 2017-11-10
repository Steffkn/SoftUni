namespace _04.WinningTicket
{
    using System;
    using System.Linq;

    class WinningTicket
    {
        static void Main()
        {
            var tickets = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .ToList();

            char[] winningSymbols = new char[] { '@', '#', '$', '^' };

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    var leftHalf = ticket.Substring(0, 10);
                    var rightHalg = ticket.Substring(10);

                    var resultLeft = MaxRepeatingCharacter(leftHalf, winningSymbols);
                    var resultRight = MaxRepeatingCharacter(rightHalg, winningSymbols);

                    if (resultLeft.Length > 5 && resultRight.Length > 5 && resultLeft[0].Equals(resultRight[0]))
                    {
                        var minLenght = resultLeft.Length < resultRight.Length ? resultLeft.Length : resultRight.Length;

                        if (minLenght <= 9)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {minLenght}{resultLeft[0]}");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {minLenght}{resultLeft[0]} Jackpot!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }

                }
            }
        }

        public static string MaxRepeatingCharacter(string input, char[] characters)
        {
            foreach (var ch in characters)
            {
                for (int i = 10; i > 5; i--)
                {
                    if (input.Contains(new string(ch, i)))
                    {
                        return new string(ch, i);
                    }
                }
            }

            return string.Empty;
        }
    }
}
