namespace _03.NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberWars
    {
        const int a = (int)'a' - 1;

        static void Main()
        {
            var input = Console.ReadLine(); // "20y 28j 45s 21i 81i";
            var firstPlayerCards = new Queue<string>(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            input = Console.ReadLine(); // "26z 9f 80a 68g 67z";
            var secondPlayerCards = new Queue<string>(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            int turn = 1;

            for (; turn < 1000001; turn++)
            {
                var fpCard = firstPlayerCards.Dequeue();
                var spCard = secondPlayerCards.Dequeue();
                var firstNumber = int.Parse(fpCard.Substring(0, fpCard.Length - 1));
                var firstLetter = (fpCard[fpCard.Length - 1] - a);
                var secondNumber = int.Parse(spCard.Substring(0, spCard.Length - 1));
                var secondLetter = (spCard[spCard.Length - 1] - a);

                if (firstNumber > secondNumber)
                {
                    firstPlayerCards.Enqueue(fpCard);
                    firstPlayerCards.Enqueue(spCard);
                }
                else if (firstNumber < secondNumber)
                {
                    secondPlayerCards.Enqueue(spCard);
                    secondPlayerCards.Enqueue(fpCard);
                }
                else
                {
                    var fpDrawList = new List<string>();
                    var spDrawList = new List<string>();
                    var fpWarSum = 0;
                    var spWarSum = 0;

                    while (fpWarSum == spWarSum && firstPlayerCards.Count != 0 && firstPlayerCards.Count != 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (firstPlayerCards.Count > 0)
                            {
                                var card = firstPlayerCards.Dequeue();
                                fpDrawList.Add(card);
                                fpWarSum += (card[card.Length - 1] - a);
                            }

                            if (secondPlayerCards.Count > 0)
                            {
                                var card = secondPlayerCards.Dequeue();
                                spDrawList.Add(card);
                                spWarSum += (card[card.Length - 1] - a);
                            }
                        }
                    }

                    if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                    {
                        Draw(turn);
                        return;
                    }

                    fpDrawList.AddRange(spDrawList);
                    var cards = new SortedSet<string>(fpDrawList);

                    if (fpWarSum > spWarSum)
                    {
                        foreach (var card in cards)
                        {
                            firstPlayerCards.Enqueue(card);
                        }
                    }
                    else if (fpWarSum < spWarSum)
                    {
                        foreach (var card in cards)
                        {
                            secondPlayerCards.Enqueue(card);
                        }
                    }
                    else
                    {
                        Draw(turn);
                        return;
                    }

                }
            }
        }

        private static void FirstPlayerWins(int turns)
        {
            Console.WriteLine($"First player wins after {turns} turns");
        }

        private static void SecondPlayerWins(int turns)
        {
            Console.WriteLine($"Second player wins after {turns} turns");
        }

        private static void Draw(int turns)
        {
            Console.WriteLine($"Draw after {turns} turns");
        }
    }
}
