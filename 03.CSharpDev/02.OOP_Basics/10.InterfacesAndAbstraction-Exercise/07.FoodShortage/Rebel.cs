﻿public class Rebel : IEntity, IBuyer
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Group { get; set; }

    public int Food { get; set; }

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Id = "rebelId";
        this.Age = age;
        this.Group = group;
        this.Food = 0;
    }

    public void BuyFood()
    {
        this.Food += 5;
    }
}
