public interface IVehical
{
    double AirConditionersFuelConsumption { get; }
    double FuelQuantity { get; set; }
    double LitersPerKm { get; set; }
    double MaxDistance { get; }

    double TankCapacity { get; }

    string Drive(double km, bool isEmpty);
    void Refuel(double liters);
}