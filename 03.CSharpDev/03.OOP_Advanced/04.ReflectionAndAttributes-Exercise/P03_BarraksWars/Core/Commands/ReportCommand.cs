
namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Attributes;

    public class ReportCommand : Command
    {
        [Inject]
        private IRepository _repository;

        public ReportCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string output = this._repository.Statistics;
            return output;
        }
    }
}
