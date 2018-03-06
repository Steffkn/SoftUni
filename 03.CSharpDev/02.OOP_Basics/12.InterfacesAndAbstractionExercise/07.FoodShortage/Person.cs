public class Person : IEntity, IBuyer, IBirthable
{
    public string Name { get; set; }

    public string Id { get; set; }

    public int Age { get; }

    public string BirthDate { get; set; }

    public int Food { get; set; }

    public Person(string name, string id, int age, string birthDate)
    {
        this.Name = name;
        this.Id = id;
        this.Age = age;
        this.BirthDate = birthDate;
        this.Food = 0;
    }

    public void BuyFood()
    {
        this.Food += 10;
    }
}
