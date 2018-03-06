using System;

public class Rectangle : IShape
{
    public int Width { get; set; }

    public int Height { get; set; }

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

}
