using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public List<Product> Products { get; set; }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Products = new List<Product>();
    }

    public override string ToString()
    {
        return this.Name;
    }
}
