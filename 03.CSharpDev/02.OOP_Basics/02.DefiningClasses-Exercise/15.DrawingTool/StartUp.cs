using System;

public class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();
        var shape = GetShape(input);
        var drawingTool = new DrawingTool(shape);
        drawingTool.Draw();
    }

    public static IShape GetShape(string input)
    {
        switch (input)
        {
            case "Square":
                return new Square(int.Parse(Console.ReadLine()));
            default:
                var a = int.Parse(Console.ReadLine());
                var b = int.Parse(Console.ReadLine());
                return new Rectangle(a, b);
        }
    }
}
