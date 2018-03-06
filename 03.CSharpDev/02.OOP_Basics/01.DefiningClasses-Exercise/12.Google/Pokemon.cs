public class Pokemon
{
    public string Name { get; set; }

    public string Type { get; set; }

    public Pokemon(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }

    public override string ToString()
    {
        return $"{Name} {Type}";
    }
}
