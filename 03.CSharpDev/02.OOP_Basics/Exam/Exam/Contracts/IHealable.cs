namespace DungeonsAndCodeWizards.Contracts
{
    using DungeonsAndCodeWizards.Models.Characters;

    public interface IHealable
    {
        void Heal(Character character);
    }
}
