using System;
using System.Collections.Generic;
using System.Text;

public class DrawingTool
{
    public IShape ObjectToDraw { get; set; }

    public DrawingTool(IShape objectToDraw)
    {
        this.ObjectToDraw = objectToDraw;
    }

    public void Draw()
    {
        Console.WriteLine($"|{new string('-', ObjectToDraw.Width)}|");
        for (int i = 0; i < ObjectToDraw.Height - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', ObjectToDraw.Width)}|");
        }
        Console.WriteLine($"|{new string('-', ObjectToDraw.Width)}|");
    }
}
