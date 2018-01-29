
namespace _07.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesis
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var bracketsStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentBracket = input[i];
                if (currentBracket == '(')
                {
                    bracketsStack.Push(currentBracket);
                }
                else if (currentBracket == '[')
                {
                    bracketsStack.Push(currentBracket);
                }
                else if (currentBracket == '{')
                {
                    bracketsStack.Push(currentBracket);
                }
                else if (bracketsStack.Count > 0)
                {
                    if (currentBracket == ')' && bracketsStack.Peek() == '(')
                    {
                        bracketsStack.Pop();
                    }
                    else if (currentBracket == ']' && bracketsStack.Peek() == '[')
                    {
                        bracketsStack.Pop();
                    }
                    else if (currentBracket == '}' && bracketsStack.Peek() == '{')
                    {
                        bracketsStack.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (input.Length > 0 && input.Length % 2 == 0)
            {
                Console.WriteLine(bracketsStack.Count == 0 ? "YES" : "NO");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
