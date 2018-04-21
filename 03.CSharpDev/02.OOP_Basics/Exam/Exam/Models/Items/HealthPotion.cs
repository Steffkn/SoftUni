using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion()
            : base(5)
        {
            this.Name = "HealthPotion";
        }

        public override void AffectCharacter(Character character)
        {
            character.ChechIfIsAlive();
            character.AddHealth(20.0);
        }
    }
}
