public class Person : IEntity, IBirthable
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

    public Person(string name, string id, int age, string birthDate)
    {
        Id = id;
        Name = name;
        Age = age;
        BirthDate = birthDate;
    }
    public string BirthDate { get; set; }
}
