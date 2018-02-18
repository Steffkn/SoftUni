public class Relative
{
    public string Name { get; set; }

    public string BirthDay { get; set; }

    public Relative(string name, string birthDay)
    {
        this.Name = name;
        this.BirthDay = birthDay;
    }

    public override string ToString()
    {
        return $"{Name} {BirthDay}";
    }
}
