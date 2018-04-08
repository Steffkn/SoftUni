namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] _data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return _data; }
            private set { _data = value; }
        }


        public abstract string Execute();
    }
}
