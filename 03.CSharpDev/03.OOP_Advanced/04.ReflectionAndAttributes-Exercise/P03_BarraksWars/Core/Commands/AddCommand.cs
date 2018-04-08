namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Core.Attributes;
    using _03BarracksFactory.Contracts;

    public class AddCommand : Command
    {
        [Inject]
        private IRepository _repository;

        [Inject]
        private IUnitFactory _unitFactory;

        public AddCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this._unitFactory.CreateUnit(unitType);
            this._repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
