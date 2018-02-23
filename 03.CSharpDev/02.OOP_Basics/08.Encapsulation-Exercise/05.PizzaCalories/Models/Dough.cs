using System;
using System.Collections.Generic;

public class Dough
{
    private const double CALORIES_MODIFIER = 2;
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 200;

    private int weight;
    private string flourType;
    private string bakingTechnique;

    private readonly IReadOnlyDictionary<string, double> flourTypeModifiers = new Dictionary<string, double>
    {
        ["white"] = 1.5,
        ["wholegrain"] = 1.0,
    };
    private readonly IReadOnlyDictionary<string, double> bakingTechniqueModifiers = new Dictionary<string, double>
    {
        ["chewy"] = 1.1,
        ["crispy"] = 0.9,
        ["homemade"] = 1.0,
    };

    public double Calories => CALORIES_MODIFIER * this.Weight * flourTypeModifiers[this.FlourType.ToLower()] *
                                     bakingTechniqueModifiers[this.BakingTechnique.ToLower()];
    public int Weight
    {
        get => this.weight;
        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }

            this.weight = value;
        }
    }

    public string FlourType
    {
        get => this.flourType;
        set
        {
            if (!flourTypeModifiers.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get => this.bakingTechnique;
        set
        {
            if (!bakingTechniqueModifiers.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    public Dough(int weight, string flourType, string bakingTechnique)
    {
        this.Weight = weight;
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
    }
}
