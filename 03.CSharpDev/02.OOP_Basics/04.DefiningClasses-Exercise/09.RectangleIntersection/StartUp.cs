using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var lineNumbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var rectangles = new Dictionary<string, Rectangle>();

        for (int i = 0; i < lineNumbers[0]; i++)
        {
            var rectangleArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var rectId = rectangleArgs[0];
            var width = double.Parse(rectangleArgs[1]);
            var height = double.Parse(rectangleArgs[2]);
            var topX = double.Parse(rectangleArgs[3]);
            var topY = double.Parse(rectangleArgs[4]);

            rectangles.Add(rectangleArgs[0], new Rectangle(rectId, width, height, new Point(topX, topY)));
        }

        for (int i = 0; i < lineNumbers[1]; i++)
        {
            var rectanglePair = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstRectangle = rectangles[rectanglePair[0]];
            var secondRectangle = rectangles[rectanglePair[1]];
            Console.WriteLine(firstRectangle.IntersectWith(secondRectangle).ToString().ToLower());
        }
    }
}
