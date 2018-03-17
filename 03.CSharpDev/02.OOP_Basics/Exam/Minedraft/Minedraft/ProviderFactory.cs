using System.Collections.Generic;

public class ProviderFactory
{
    public Provider GetProvider(List<string> arguments)
    {
        string providerType = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        switch (providerType)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                return null;
        }
    }
}
