using System;

public class Kitten : Cat
{
    public Kitten(string name, int age)
        : base(name, age, "Female")
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}
