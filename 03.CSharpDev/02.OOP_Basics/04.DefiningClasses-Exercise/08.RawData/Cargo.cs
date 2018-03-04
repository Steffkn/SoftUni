public class Cargo
{
    public uint CargoWeight { get; set; }

    public string CargoType { get; set; }

    public Cargo(uint cargoWeight, string cargoType)
    {
        this.CargoWeight = cargoWeight;
        this.CargoType = cargoType;
    }
}
