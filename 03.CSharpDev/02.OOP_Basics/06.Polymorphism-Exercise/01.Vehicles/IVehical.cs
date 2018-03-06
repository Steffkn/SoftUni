public interface IVehical
{
    double AirConditionersFuelConsumption { get; }
    double FuelQuantity { get; set; }
    double LitersPerKm { get; set; }
    double MaxDistance { get; }

    string Drive(double km);
    void Refuel(double liters);
}