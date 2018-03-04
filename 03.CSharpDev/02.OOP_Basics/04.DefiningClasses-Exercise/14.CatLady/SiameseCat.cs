using System;
using System.Collections.Generic;
using System.Text;

public class SiameseCat : Cat
{
    public int EarSize { get; set; }

    public SiameseCat(string name, int earSize)
        : base(name, "Siamese")
    {
        this.EarSize = earSize;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.EarSize}";
    }
}
