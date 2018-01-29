namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SimpleTextEditor
    {
        static void Main()
        {
            var sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            var memento = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "1":
                        memento.Push(sb.ToString());
                        sb.Append(tokens[1]);
                        break;
                    case "2":
                        int count = int.Parse(tokens[1]);
                        memento.Push(sb.ToString());
                        sb.Remove(sb.Length - count, count);
                        break;
                    case "3":
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;
                    case "4":
                        sb.Clear();
                        sb.Append(memento.Pop());
                        break;
                }
            }
        }
    }
}
