public class Person : IEntity
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int Age { get; }

    public Person(string name, string id, int age)
    {
        this.Name = name;
        this.Id = id;
        this.Age = age;
    }
}
