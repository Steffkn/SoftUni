
namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Attributes;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commands = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IExecutable)));
            var fullCommandName = commandName + "command";
            var commandType = commands.FirstOrDefault(c => c.Name.ToLower() == fullCommandName);

            if (commandType != null)
            {
                var command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });
                var fields = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(f => f.GetCustomAttributes<InjectAttribute>().Any());

                foreach (var fieldInfo in fields)
                {
                    var f = fieldInfo.FieldType.Name;
                    if (f == "IRepository")
                    {
                        fieldInfo.SetValue(command, repository);
                    }
                    else if (f == "IUnitFactory")
                    {
                        fieldInfo.SetValue(command, unitFactory);
                    }
                }

                return command;
            }

            throw new InvalidOperationException("Invalid command!");
        }
    }
}
