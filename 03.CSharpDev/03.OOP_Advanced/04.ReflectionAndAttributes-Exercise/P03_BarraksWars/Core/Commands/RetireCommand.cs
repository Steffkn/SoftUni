
namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Core.Attributes;
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository _repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this._repository.RemoveUnit(unitType);
            string output = unitType + " retired!";
            return output;
        }
    }
}
