using System;

class StartUp
{
    static void Main()
    {
        try
        {
            string input = Console.ReadLine();
            var pizza = new Pizza(input.Split(' ')[1]);

            var doughArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            pizza.Dough = new Dough(int.Parse(doughArgs[3]), doughArgs[1], doughArgs[2]);

            while ((input = Console.ReadLine()) != "END")
            {
                var commandArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                pizza.AddTopping(new Topping(commandArgs[1], int.Parse(commandArgs[2])));
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
