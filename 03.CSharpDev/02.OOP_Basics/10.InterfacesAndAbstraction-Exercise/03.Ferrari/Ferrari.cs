using System;

public class Ferrari : ICar
{
    public string Model { get; set; }
    public string Driver { get; set; }

    public Ferrari(string driver)
    {
        this.Model = "488-Spider";
        this.Driver = driver;
    }

    public string UseBreaks()
    {
        return "Brakes!";
    }

    public string UseGasPedal()
    {
        return "Zadu6avam sA!";
    }
}
