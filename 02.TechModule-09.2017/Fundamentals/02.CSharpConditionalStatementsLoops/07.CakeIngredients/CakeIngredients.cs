namespace _07.CakeIngredients
{
    using System;

    public class CakeIngredients
    {
        static void Main()
        {
            int numberOfIngredients = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "bake!")
                {
                    Console.WriteLine($"Preparing cake with {numberOfIngredients} ingredients.");
                    break;
                }
                else
                {
                    numberOfIngredients++;
                    Console.WriteLine($"Adding ingredient {input}.");
                }
            }
        }
    }
}