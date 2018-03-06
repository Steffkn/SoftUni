using System;

public class Child : Person
{
    private string name;

    private int age;

    public Child(string name, int age)
        : base(name, age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value > 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }

            this.age = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
}
