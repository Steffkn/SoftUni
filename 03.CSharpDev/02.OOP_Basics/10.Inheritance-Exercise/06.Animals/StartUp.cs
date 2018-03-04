using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "Beast!")
        {
            var animalType = input.Trim();
            var animalArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                var animalName = animalArgs[0].Trim();
                var animalAge = int.Parse(animalArgs[1]);
                var animalGender = animalArgs[2].Trim();
                Animal animal;
                switch (animalType)
                {
                    case "Dog":
                        animal = new Dog(animalName, animalAge, animalGender);
                        break;
                    case "Cat":
                        animal = new Cat(animalName, animalAge, animalGender);
                        break;
                    case "Kitten":
                        animal = new Kitten(animalName, animalAge);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(animalName, animalAge);
                        break;
                    case "Frog":
                        animal = new Frog(animalName, animalAge, animalGender);
                        break;
                    default:
                        throw new ArgumentException(ExceptionMessages.InvalidValueMessage);
                }

                Console.WriteLine(animal);
                animal.ProduceSound();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
