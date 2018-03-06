public class Citizen : IPerson
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
