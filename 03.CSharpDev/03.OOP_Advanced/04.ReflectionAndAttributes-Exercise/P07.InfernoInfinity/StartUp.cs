namespace P07.InfernoInfinity
{
    using P07.InfernoInfinity.Factories;

    public class StartUp
    {
        static void Main()
        {
            var gemFactory = new GemsFactory();
            var weaponFactory = new WeaponsFactory();

            var engine = new Engine(weaponFactory, gemFactory);
            engine.Run();
        }
    }
}
