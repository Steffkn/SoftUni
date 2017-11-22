// my task was to fix the bugs so that it gives correct answer, this code is not mine

namespace _16.InstructionSet
{
    using System;

    public class InstructionSet
    {
        static void Main()
        {
            while (true)
            {
                string operation = Console.ReadLine();

                string[] codeArgs = operation.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long operandOne = 0;
                long operandTwo = 0;
                long result = 0;

                switch (codeArgs[0])
                {
                    case "INC":
                        operandOne = long.Parse(codeArgs[1]);
                        result = operandOne + 1;
                        break;
                    case "DEC":
                        operandOne = long.Parse(codeArgs[1]);
                        result = operandOne - 1;
                        break;
                    case "ADD":
                        operandOne = long.Parse(codeArgs[1]);
                        operandTwo = long.Parse(codeArgs[2]);
                        result = operandOne + operandTwo;
                        break;
                    case "MLA":
                        operandOne = long.Parse(codeArgs[1]);
                        operandTwo = long.Parse(codeArgs[2]);
                        result = operandOne * operandTwo;
                        break;
                    case "END":
                        return;
                }

                Console.WriteLine(result);
            }
        }
    }
}