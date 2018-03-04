using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MIN_NAME_LENGHT = 1;
    private const int MAX_NAME_LENGHT = 15;
    private const int MIN_NUMBER_OF_TOPPINGS = 0;
    private const int MAX_NUMBER_OF_TOPPINGS = 10;
    private readonly string PizzaNameMissingOrOutOfRangeExceptionMessage = $"Pizza name should be between {MIN_NAME_LENGHT} and {MAX_NAME_LENGHT} symbols.";
    private readonly string NumberOfToppingsOutOfRangeExceptionMessage = $"Number of toppings should be in range [{MIN_NUMBER_OF_TOPPINGS}..{MAX_NUMBER_OF_TOPPINGS}].";

    private string name;

    public string Name
    {
        get => this.name;

        private set
        {
            if (string.IsNullOrEmpty(value.Trim()) || (value.Length < MIN_NAME_LENGHT || value.Length > MAX_NAME_LENGHT))
            {
                throw new ArgumentException(PizzaNameMissingOrOutOfRangeExceptionMessage);
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
            return this.Toppings.Sum(x => x.Calories) + this.Dough.Calories;
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
        if (this.Toppings.Count > MAX_NUMBER_OF_TOPPINGS)
        {
            throw new ArgumentException(NumberOfToppingsOutOfRangeExceptionMessage);
        }
    }
}
