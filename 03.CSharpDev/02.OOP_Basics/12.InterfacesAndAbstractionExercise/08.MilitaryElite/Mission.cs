public class Mission
{
    public string Name { get; set; }

    public string State { get; set; }

    public Mission(string name, string state)
    {
        this.Name = name;
        this.State = state;
    }

    public override string ToString()
    {
        return $"  Code Name: {this.Name} State: {this.State}";
    }
}
