using System;
using System.Collections.Generic;
using System.Text;

public class CymricCat : Cat
{
    public double FurLenght { get; set; }

    public CymricCat(string name, double furLenght)
        : base(name, "Cymric")
    {
        this.FurLenght = furLenght;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.FurLenght:f2}";
    }
}
