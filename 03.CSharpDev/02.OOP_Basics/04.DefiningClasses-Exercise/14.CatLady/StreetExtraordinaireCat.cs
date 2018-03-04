using System;
using System.Collections.Generic;
using System.Text;

public class StreetExtraordinaireCat : Cat
{
    public int DecibelsOfMeows { get; set; }

    public StreetExtraordinaireCat(string name, int decibelsOfMeows)
        : base(name, "StreetExtraordinaire")
    {
        this.DecibelsOfMeows = decibelsOfMeows;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.DecibelsOfMeows}";
    }
}
