﻿public abstract class Feline : Mammal
{
    protected Feline(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    public string Breed { get; }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}