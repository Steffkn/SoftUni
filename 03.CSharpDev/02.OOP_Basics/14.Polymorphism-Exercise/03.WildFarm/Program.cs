using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public class Program
{
    static void Main()
    {
        var input = string.Empty;
        var animals = new List<Animal>();
        while ((input = Console.ReadLine()) != "End")
        {
            var animalArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Animal newAnimal = GetAnimalFactory(animalArgs);
            Console.WriteLine(newAnimal.GiveFoodNow);

            var foodArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Food newFood = GetFoodFactory(foodArgs);

            if (!newAnimal.CanEat(newFood))
            {
                Console.WriteLine($"{newAnimal.GetType().Name} does not eat {newFood.GetType().Name}!");
            }
            else
            {
                newAnimal.Eat(newFood.Quantity);
            }

            animals.Add(newAnimal);
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static Food GetFoodFactory(string[] foodArgs)
    {
        var foodType = foodArgs[0];
        var foodQuantity = int.Parse(foodArgs[1]);

        switch (foodType)
        {
            case "Fruit":
                return new Fruit(foodQuantity);
            case "Meat":
                return new Meat(foodQuantity);
            case "Seeds":
                return new Seeds(foodQuantity);
            case "Vegetable":
                return new Vegetable(foodQuantity);
            default:
                throw new ArgumentException();
        }
    }

    private static Animal GetAnimalFactory(string[] commandArgs)
    {
        var animalType = commandArgs[0];
        var animalName = commandArgs[1];
        var animalWeight = double.Parse(commandArgs[2]);
        switch (animalType)
        {
            case "Dog":
                return new Dog(animalName, animalWeight, commandArgs[3]);
            case "Mouse":
                return new Mouse(animalName, animalWeight, commandArgs[3]);
            case "Cat":
                return new Cat(animalName, animalWeight, commandArgs[3], commandArgs[4]);
            case "Tiger":
                return new Tiger(animalName, animalWeight, commandArgs[3], commandArgs[4]);
            case "Owl":
                return new Owl(animalName, animalWeight, double.Parse(commandArgs[3]));
            case "Hen":
                return new Hen(animalName, animalWeight, double.Parse(commandArgs[3]));
            default:
                throw new ArgumentException("Invalid animal");
        }
    }
}
