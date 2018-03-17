using System;
using System.Collections.Generic;

public class DriverFactory
{
    private TyreFactory tyreFactory = new TyreFactory();

    public Driver GetDriver(List<string> commandArgs, Car car)
    {
        string type = commandArgs[0];
        string driverName = commandArgs[1];
       
        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(driverName, car);
            case "Endurance":
                return new EnduranceDriver(driverName, car);
            default:
                throw new ArgumentException();
        }
    }
}
