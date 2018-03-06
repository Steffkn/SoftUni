public abstract class Mood
{
    public string Name { get; set; }

    public Mood(string name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}
