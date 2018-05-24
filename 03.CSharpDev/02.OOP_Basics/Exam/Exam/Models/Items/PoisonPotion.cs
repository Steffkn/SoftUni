using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion()
            : base(5)
        {
            this.Name = "PoisonPotion";
        }

        public override void AffectCharacter(Character character)
        {
            character.ChechIfIsAlive();
            character.TakeTrueDamage(20.0);
        }
    }
}
