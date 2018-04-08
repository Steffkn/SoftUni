namespace P07.InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        public Sword(string name, Rarity rarity)
            : base(name, rarity, 4, 6, 3)
        {
        }
    }
}
