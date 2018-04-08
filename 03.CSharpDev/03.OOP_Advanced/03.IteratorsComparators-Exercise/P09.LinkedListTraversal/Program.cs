namespace P09.LinkedListTraversal
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var customLinkedList = new CustomLinkedList<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string command = commandArgs[0];
                int currentNumber = int.Parse(commandArgs[1]);

                switch (command)
                {
                    case "Add":
                        var newNode = new Node<int>(currentNumber);
                        if (customLinkedList.Count == 0)
                        {
                            customLinkedList = new CustomLinkedList<int>(newNode);
                        }
                        else
                        {
                            customLinkedList.Add(currentNumber);
                        }
                        break;
                    case "Remove":
                        if (customLinkedList.Count > 0)
                        {
                            customLinkedList.Remove(currentNumber);
                        }
                        break;
                }
            }

            Console.WriteLine(customLinkedList.Count);
            Console.WriteLine(string.Join(" ", customLinkedList));
        }
    }
}
