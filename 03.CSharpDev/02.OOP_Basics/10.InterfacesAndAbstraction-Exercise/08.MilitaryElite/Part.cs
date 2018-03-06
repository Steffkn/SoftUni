public class Part
{
    public string Name { get; set; }

    public int Hours { get; set; }

    public Part(string name, int hours)
    {
        this.Name = name;
        this.Hours = hours;
    }

    public override string ToString()
    {
        return $"  Part Name: {this.Name} Hours Worked: {this.Hours}";
    }
}
