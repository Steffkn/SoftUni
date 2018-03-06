using System;

public class Product
{
    private decimal _cost;
    private string _name;

    public string Name
    {
        get => this._name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this._name = value;
        }
    }

    public decimal Cost
    {
        get => this._cost;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this._cost = value;
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
