namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;

    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; }

        public string Name { get; protected set; }

        public virtual void AffectCharacter(Character character)
        {
            character.ChechIfIsAlive();
        }
    }
}
