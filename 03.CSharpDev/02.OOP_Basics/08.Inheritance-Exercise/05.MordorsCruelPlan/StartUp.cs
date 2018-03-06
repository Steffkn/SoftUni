using System;

public class StartUp
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        var happiness = GetHappiness(input);

        var mood = GetMood(happiness);

        Console.WriteLine(happiness);
        Console.WriteLine(mood.Name);
    }

    private static Mood GetMood(int happiness)
    {
        if (happiness < -5)
        {
            return new Angry();
        }
        else if (happiness < 1)
        {
            return new Sad();
        }
        else if (happiness <= 15)
        {
            return new Happy();
        }
        else
        {
            return new JavaScript();
        }
    }

    public static int GetHappiness(string[] input)
    {
        int happiness = 0;
        Food currentFood;
        foreach (string s in input)
        {
            switch (s.ToLower())
            {
                case "cram":
                    currentFood = new Cram();
                    break;
                case "lembas":
                    currentFood = new Lembas();
                    break;
                case "apple":
                    currentFood = new Apple();
                    break;
                case "melon":
                    currentFood = new Melon();
                    break;
                case "honeycake":
                    currentFood = new HoneyCake();
                    break;
                case "mushrooms":
                    currentFood = new Mushroom();
                    break;
                default:
                    currentFood = new OtherFood();
                    break;

            }
            happiness += currentFood.HappinessPoints;
        }

        return happiness;
    }
}
