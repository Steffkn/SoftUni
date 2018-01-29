namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;

    public class MaximumElement
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbersStack = new Stack<int>();
            var trackStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine();
                if (inputs[0] == '1')
                {
                    var number = int.Parse(inputs.Substring(1));
                    numbersStack.Push(number);

                    if (trackStack.Count != 0)
                    {
                        if (trackStack.Peek() < number)
                        {
                            trackStack.Push(number);
                        }
                        else
                        {
                            trackStack.Push(trackStack.Peek());
                        }
                    }
                    else
                    {
                        trackStack.Push(number);
                    }
                }
                else if (inputs[0] == '2')
                {
                    numbersStack.Pop();
                    trackStack.Pop();
                }
                else
                {
                    Console.WriteLine(trackStack.Peek());
                }
            }
        }
    }
}
