using System;
using System.Collections.Generic;

public class Topping
{
    private readonly double CALORIES_MODIFIER = 2;
    private readonly int MIN_WEIGHT = 1;
    private readonly int MAX_WEIGHT = 50;
    private readonly string WeightOutOfRangeExceptionMessage = "{0} weight should be in the range [{1}..{2}].";
    private readonly string InvalidToppingExceptionMessage = "Cannot place {0} on top of your pizza.";

    private int weight;
    private string toppingType;

    private readonly IReadOnlyDictionary<string, double> toppingTypeModifiers = new Dictionary<string, double>
    {
        ["meat"] = 1.2,
        ["veggies"] = 0.8,
        ["cheese"] = 1.1,
        ["sauce"] = 0.9,
    };

    public double Calories => CALORIES_MODIFIER * this.Weight * toppingTypeModifiers[this.ToppingType.ToLower()];

    public int Weight
    {
        get => this.weight;
        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException(string.Format(WeightOutOfRangeExceptionMessage, this.ToppingType, MIN_WEIGHT, MAX_WEIGHT));
            }

            this.weight = value;
        }
    }

    public string ToppingType
    {
        get => this.toppingType;
        set
        {
            if (!toppingTypeModifiers.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException(string.Format(InvalidToppingExceptionMessage, value));
            }

            this.toppingType = value;
        }
    }

    public Topping(string type, int weight)
    {
        this.ToppingType = type;
        this.Weight = weight;
    }
}
