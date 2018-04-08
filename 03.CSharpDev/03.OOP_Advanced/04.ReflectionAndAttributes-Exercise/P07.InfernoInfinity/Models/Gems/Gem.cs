namespace P07.InfernoInfinity.Models.Gems
{
    using P07.InfernoInfinity.Interfaces;

    public abstract class Gem : IHaveStats, IGem
    {
        private readonly int _strength;
        private readonly int _agility;
        private readonly int _vitality;

        protected Gem(int strength, int agility, int vitality, Clarity clarity)
        {
            this._strength = strength;
            this._agility = agility;
            this._vitality = vitality;
            this.Clarity = clarity;
        }

        public int Strength => this._strength + (int)this.Clarity;

        public int Agility => this._agility + (int)this.Clarity;

        public int Vitality => this._vitality + (int)this.Clarity;

        public Clarity Clarity { get; }
    }
}
