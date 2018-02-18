public class Rectangle
{
    public string Id { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public Point TopLeftPoint { get; set; }

    public Point BottomRightPoint { get; set; }

    public Rectangle(string id, double width, double height, Point topLeftPoint)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.TopLeftPoint = topLeftPoint;
        this.BottomRightPoint = new Point(this.TopLeftPoint.X + this.Width, this.TopLeftPoint.Y + this.Height);
    }

    public bool IntersectWith(Rectangle other)
    {
        return this.TopLeftPoint.X <= other.BottomRightPoint.X && this.TopLeftPoint.Y <= other.BottomRightPoint.Y
            && this.BottomRightPoint.X >= other.TopLeftPoint.X && this.BottomRightPoint.Y >= other.TopLeftPoint.Y;
    }
}
