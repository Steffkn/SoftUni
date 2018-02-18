using System;
using System.Collections.Generic;
using System.Text;

public abstract class Cat : IAnimal
{
    public string Name { get; set; }

    public string Breed { get; set; }

    protected Cat(string name, string breed)
    {
        this.Name = name;
        this.Breed = breed;
    }
}
