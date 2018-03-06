public class Engine
{
    public uint EngineSpeed { get; set; }
    public uint EnginePower { get; set; }

    public Engine(uint engineSpeed, uint enginePower)
    {
        this.EngineSpeed = engineSpeed;
        this.EnginePower = enginePower;
    }
}
