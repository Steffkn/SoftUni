public class Tire
{
    public double Pressure { get; set; }

    public sbyte Age { get; set; }

    public Tire(double pressure, sbyte age)
    {
        this.Pressure = pressure;
        this.Age = age;
    }
}
