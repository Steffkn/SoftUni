using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private decimal _cost;
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            _name = value;
        }
    }

    public decimal Cost
    {
        get => _cost;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            _cost = value;
        }
    }

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public override string ToString()
    {
        return this.Name;
    }
}
