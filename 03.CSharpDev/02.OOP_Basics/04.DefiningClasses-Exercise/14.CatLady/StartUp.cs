using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        var cats = new Dictionary<string, Cat>();

        var input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var catArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var catName = catArgs[1];
            cats.Add(catName, CatFactory(catArgs));
        }

        input = Console.ReadLine().Trim();

        Console.WriteLine(cats[input]);
    }

    public static Cat CatFactory(string[] catArgs)
    {
        var catBreed = catArgs[0].Trim();
        var catName = catArgs[1].Trim();

        switch (catBreed)
        {
            case "Siamese":
                return new SiameseCat(catName, int.Parse(catArgs[2]));
            case "Cymric":
                return new CymricCat(catName, double.Parse(catArgs[2]));
            default:
                return new StreetExtraordinaireCat(catName, int.Parse(catArgs[2]));
        }
    }

}
