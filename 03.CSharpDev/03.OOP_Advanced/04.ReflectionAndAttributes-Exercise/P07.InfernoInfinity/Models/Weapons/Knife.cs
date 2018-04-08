namespace P07.InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        public Knife(string name, Rarity rarity)
            : base(name, rarity, 3, 4, 2)
        {
        }
    }
}
