using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MIN_NAME_LENGHT = 1;
    private const int MAX_NAME_LENGHT = 15;

    private string name;

    public string Name
    {
        get => this.name;

        private set
        {
            if (string.IsNullOrEmpty(value.Trim()) || (value.Length < MIN_NAME_LENGHT || value.Length > MAX_NAME_LENGHT))
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    private List<Topping> Toppings { get; set; }

    public Dough Dough { get; set; }

    public double TotalCalories
    {
        get
        {
            return this.Toppings.Select(x => x.Calories).Sum() + this.Dough.Calories;
        }
    }

    public Pizza(string name)
    {
        this.Name = name;
        this.Toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
        if (this.Toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }
}
