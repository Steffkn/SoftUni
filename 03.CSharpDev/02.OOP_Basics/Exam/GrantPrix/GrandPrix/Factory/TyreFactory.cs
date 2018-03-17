using System;
using System.Collections.Generic;

public class TyreFactory
{
    public Tyre GetTyre(List<string> commandArgs)
    {
        string tyreType = commandArgs[4];
        var tyreHardness = double.Parse(commandArgs[5]);

        switch (tyreType)
        {
            case "Hard":
                return new HardTyre(tyreHardness);
            case "Ultrasoft":
                var tyreGrip = double.Parse(commandArgs[6]);
                return new UltrasoftTyre(tyreHardness, tyreGrip);
            default:
                throw new ArgumentException();
        }
    }
}
