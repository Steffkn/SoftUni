
namespace _03BarracksFactory
{
    using Contracts;
    using _03BarracksFactory.Core;
    using _03BarracksFactory.Core.Factories;
    using _03BarracksFactory.Data;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
